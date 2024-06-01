using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Common.Utilities;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kemet.ERP.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IAuthRepository authRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
            => (_authRepository, _accountRepository, _unitOfWork) = (authRepository, accountRepository, unitOfWork);


        public async Task<ApiResponse> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return new ApiResponse(false, $"User with ID '{request.UserId}' was not found.");

            var role =
                await _authRepository.GetRoleByNameAsync(request.Role, cancellationToken);

            if (role is null)
                return new ApiResponse(false, $"Role with name '{request.Role}' was not found.");

            var userRoles =
                await _authRepository.GetUserRolesAsync(user);

            if (userRoles != null && userRoles.Any(x => x == request.Role))
                return new ApiResponse(false, $"Role with name '{request.Role}' is already assigned to the user.");

            var result =
                await _authRepository.AddUserRoleAsync(user, request.Role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{request.Role}' has been successfully added to the user '{user.UserName}'.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return new ApiResponse(false, $"User with ID '{request.UserId}' was not found.");

            var role =
                await _authRepository.GetRoleByNameAsync(request.Role, cancellationToken);

            if (role is null)
                return new ApiResponse(false, $"Role with name '{request.Role}' was not found.");

            var userRoles =
                await _authRepository.GetUserRolesAsync(user);

            if (userRoles is null || userRoles.Any(x => x == request.Role) == false)
                return new ApiResponse(false, $"Role with name '{request.Role}' has not been assigned to the user before.");

            var result =
                await _authRepository.RemoveUserRoleAsync(user, request.Role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{request.Role}' has been successfully removed from the user '{user.UserName}'.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByTokenAsync(request.Token, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid token.");

            if (user.EmailConfirmed == false)
                return new ApiResponse(false, "Please confirm your email before proceeding.");

            var refreshToken =
                user.RefreshTokens.Single(t => t.Token == request.Token);

            if (refreshToken.IsActive == false)
                return new ApiResponse(false, "Inactive token.");

            refreshToken.RevokedOn = DateTime.Now;

            var userInfo =
                await ConfigureAndGetUserInfo(user, cancellationToken);

            return new ApiResponse(true, userInfo);
        }

        public async Task<ApiResponse> RevokeTokenAsync(TokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByTokenAsync(request.Token, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid token.");

            var refreshToken =
                user.RefreshTokens.Single(t => t.Token == request.Token);

            if (refreshToken.IsActive == false)
                return new ApiResponse(false, "Token already expired.");

            refreshToken.RevokedOn = DateTime.Now;

            _authRepository.UpdateUser(user);

            await _authRepository.CommitAsync(cancellationToken);

            return new ApiResponse(true, "Token revoked successfully.");
        }

        public async Task<ApiResponse> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByNameAsync(request.UserName, cancellationToken);

            if (user is null)
                user = await _accountRepository.GetUserByEmailAsync(request.UserName, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid username or password.");

            var isAuthorized =
                await _authRepository.CheckPasswordAsync(user, request.Password, cancellationToken);

            if (isAuthorized == false)
                return new ApiResponse(false, "Invalid username or password.");

            if (user.EmailConfirmed == false)
                return new ApiResponse(false, "Please confirm your email before proceeding.");

            var userInfo =
                await ConfigureAndGetUserInfo(user, cancellationToken);

            return new ApiResponse(true, userInfo);
        }








        private string GenerateJwtToken(AppUser user, List<string>? roles)
        {
            var roleClaims = new List<Claim>();

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    roleClaims.Add(new Claim("roles", role));
                }
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.UserName ?? string.Empty),
                new Claim("Email", user.Email ?? string.Empty)
            }
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.GetJWT("Key")));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: ConfigurationHelper.GetJWT("Issuer"),
                audience: ConfigurationHelper.GetJWT("Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(ConfigurationHelper.GetJWT("AccessTokenExpirationInMinutes"))),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private async Task<UserInfoDto> ConfigureAndGetUserInfo(AppUser user, CancellationToken cancellationToken = default)
        {
            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresOn = DateTime.Now.AddDays(int.Parse(ConfigurationHelper.GetJWT("RefreshTokenExpirationInDays"))),
                CreatedOn = DateTime.Now
            };

            var roles =
                (await _authRepository.GetUserRolesAsync(user, cancellationToken))?.ToList();

            var permissions
                = (await GetUserPermissions(user, roles, cancellationToken))?.ToList();

            var userInfoDto = new UserInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user?.UserName,
                Email = user?.Email,
                AccessToken = GenerateJwtToken(user, roles),
                RefreshToken = refreshToken.Token,
                TokenExpiration = refreshToken.ExpiresOn,
                Roles = roles,
                Permissions = permissions
            };

            user.RefreshTokens.Add(refreshToken);
            _authRepository.UpdateUser(user);
            await _authRepository.CommitAsync(cancellationToken);

            return userInfoDto;
        }

        private async Task<IEnumerable<UserModuleDto>?> GetUserPermissions(AppUser user, List<string>? roles, CancellationToken cancellationToken = default)
        {
            if (roles is null)
                return null;

            var permissions = await _unitOfWork.Repository().FindAsync<RolePageMaster>(
                x => roles.Contains(x.GetRole.Name),
                null, null, null, cancellationToken,
                "GetPage.GetMenu.GetModule");


            var userPermissions = permissions
            .GroupBy(rp => new { rp.GetPage?.GetMenu?.GetModule?.Name, rp.GetPage?.GetMenu?.GetModule?.Label, rp.GetPage?.GetMenu?.GetModule?.Icon })
            .Select(group => new UserModuleDto
            {
                Module = group.Key.Name,
                Label = group.Key.Label,
                Icon = group.Key.Icon,
                Menus = group
                    .GroupBy(rp => new { rp.GetPage?.GetMenu?.Name, rp.GetPage?.GetMenu?.Label, rp.GetPage?.GetMenu?.Icon })
                    .Select(menuGroup => new UserMenuDto
                    {
                        Menu = menuGroup.Key.Name,
                        Label = menuGroup.Key.Label,
                        Icon = menuGroup.Key.Icon,
                        Pages = menuGroup
                            .Select(rp => new UserPageDto
                            {
                                Page = rp.GetPage?.Name,
                                Url = rp.GetPage?.Url,
                                Label = rp.GetPage?.Label,
                                Icon = rp.GetPage?.Icon,
                                Create = rp.Create,
                                Update = rp.Update,
                                Delete = rp.Delete,
                                Export = rp.Export
                            }).ToList()
                    }).ToList()
            }).ToList();

            return userPermissions;
        }
    }
}
