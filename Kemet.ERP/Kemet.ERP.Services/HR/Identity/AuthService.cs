using Kemet.ERP.Abstraction.HR.Identity;
using Kemet.ERP.Contracts.HR.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.Entities.HR.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Shared.Utilities;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kemet.ERP.Services.HR.Identity
{
    internal class AuthService : IAuthService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public AuthService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _hrRepositoryManager.AccountRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return new ApiResponse(false, $"User with ID '{request.UserId}' was not found.");

            var role =
                await _hrRepositoryManager.AuthRepository.GetRoleByNameAsync(request.Role, cancellationToken);

            if (role is null)
                return new ApiResponse(false, $"Role with name '{request.Role}' was not found.");

            var userRoles =
                await _hrRepositoryManager.AuthRepository.GetUserRolesAsync(user);

            if (userRoles != null && userRoles.Any(x => x == request.Role))
                return new ApiResponse(false, $"Role with name '{request.Role}' is already assigned to the user.");

            var result =
                await _hrRepositoryManager.AuthRepository.AddUserRoleAsync(user, request.Role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{request.Role}' has been successfully added to the user '{user.UserName}'.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _hrRepositoryManager.AccountRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return new ApiResponse(false, $"User with ID '{request.UserId}' was not found.");

            var role =
                await _hrRepositoryManager.AuthRepository.GetRoleByNameAsync(request.Role, cancellationToken);

            if (role is null)
                return new ApiResponse(false, $"Role with name '{request.Role}' was not found.");

            var userRoles =
                await _hrRepositoryManager.AuthRepository.GetUserRolesAsync(user);

            if (userRoles is null || userRoles.Any(x => x == request.Role) == false)
                return new ApiResponse(false, $"Role with name '{request.Role}' has not been assigned to the user before.");

            var result =
                await _hrRepositoryManager.AuthRepository.RemoveUserRoleAsync(user, request.Role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{request.Role}' has been successfully removed from the user '{user.UserName}'.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> CreateRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _hrRepositoryManager.AuthRepository.GetRoleByNameAsync(role, cancellationToken);

            if (roleEntity != null)
                return new ApiResponse(false, $"Role with name '{role}' already exist.");

            var result =
                await _hrRepositoryManager.AuthRepository.CreateRoleAsync(role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{role}' has been created successfully.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse> DeleteRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _hrRepositoryManager.AuthRepository.GetRoleByNameAsync(role, cancellationToken);

            if (roleEntity is null)
                return new ApiResponse(false, $"Role with name '{role}' was not found.");

            var result =
                await _hrRepositoryManager.AuthRepository.DeleteRoleAsync(role, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, $"Role '{role}' has been deleted successfully.");

            return new ApiResponse(false, $"Something went wrong");
        }

        public async Task<ApiResponse?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.AuthRepository.GetRoleByIdAsync(id, cancellationToken);

            if (entity is null)
                return new ApiResponse(false, $"Role with ID '{id}' was not found.");

            var entityDto =
                entity.Adapt<RoleDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetRolesAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _hrRepositoryManager.AuthRepository.GetRolesAsync(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RoleDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _hrRepositoryManager.AccountRepository.GetUserByTokenAsync(request.Token, cancellationToken);

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
                await _hrRepositoryManager.AccountRepository.GetUserByTokenAsync(request.Token, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid token.");

            var refreshToken =
                user.RefreshTokens.Single(t => t.Token == request.Token);

            if (refreshToken.IsActive == false)
                return new ApiResponse(false, "Token already expired.");

            refreshToken.RevokedOn = DateTime.Now;

            _hrRepositoryManager.AuthRepository.UpdateUser(user);

            await _hrRepositoryManager.UnitOfWork.SaveChangesAsync();

            return new ApiResponse(true, "Token revoked successfully.");
        }

        public async Task<ApiResponse> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken = default)
        {
            var user =
                await _hrRepositoryManager.AccountRepository.GetUserByNameAsync(request.UserName, cancellationToken);

            if (user is null)
                user = await _hrRepositoryManager.AccountRepository.GetUserByEmailAsync(request.UserName, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Invalid username or password.");

            var isAuthorized =
                await _hrRepositoryManager.AuthRepository.CheckPasswordAsync(user, request.Password, cancellationToken);

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
                (await _hrRepositoryManager.AuthRepository.GetUserRolesAsync(user, cancellationToken))?.ToList();

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
            _hrRepositoryManager.AuthRepository.UpdateUser(user);
            await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return userInfo;
        }
    }
}
