using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Shared.Utilities;
using Mapster;
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

        public AuthService(IAuthRepository authRepository, IAccountRepository accountRepository)
            => (_authRepository, _accountRepository) = (authRepository, accountRepository);


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

        public async Task<ApiResponse> CreateRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _authRepository.GetRoleByNameAsync(role, cancellationToken);

            if (roleEntity != null)
                return new ApiResponse(false, $"Role with name '{role}' already exist.");

            var result =
                await _authRepository.CreateRoleAsync(role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{role}' has been created successfully.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> DeleteRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _authRepository.GetRoleByNameAsync(role, cancellationToken);

            if (roleEntity is null)
                return new ApiResponse(false, $"Role with name '{role}' was not found.");

            var result =
                await _authRepository.DeleteRoleAsync(role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{role}' has been deleted successfully.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _authRepository.GetRoleByIdAsync(id, cancellationToken);

            if (entity is null)
                return new ApiResponse(false, $"Role with ID '{id}' was not found.");

            var entityDto =
                entity.Adapt<RoleDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetRolesAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _authRepository.GetRolesAsync(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RoleDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.GetUserByTokenAsync(request.Token, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid token.");

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

            var userInfo = new UserInfoDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user?.UserName,
                Email = user?.Email,
                AccessToken = GenerateJwtToken(user, roles),
                RefreshToken = refreshToken.Token,
                TokenExpiration = refreshToken.ExpiresOn,
                Roles = roles
            };

            user.RefreshTokens.Add(refreshToken);
            _authRepository.UpdateUser(user);
            await _authRepository.CommitAsync(cancellationToken);

            return userInfo;
        }
    }
}
