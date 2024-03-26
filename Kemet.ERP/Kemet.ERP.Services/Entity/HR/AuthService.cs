using Kemet.ERP.Abstraction.IEntity.HR;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Shared.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Kemet.ERP.Services.Entity.HR
{
    internal class AuthService : IAuthService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public AuthService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken = default)
        {
            var user = await _hrRepositoryManager.AccountRepository.GetByNameAsync(request.UserName);

            if (user is null) user = await _hrRepositoryManager.AccountRepository.GetByEmailAsync(request.UserName);

            if (user is null) return new ApiResponse(false, "Invalid username or password.");

            var isAuthorized = await _hrRepositoryManager.AuthRepository.CheckPasswordAsync(user, request.Password, cancellationToken);

            if (isAuthorized == false) return new ApiResponse(false, "Invalid username or password.");

            var refreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                ExpiresOn = DateTime.Now.AddDays(int.Parse(ConfigurationHelper.GetJWT("RefreshTokenExpirationInDays"))),
                CreatedOn = DateTime.Now
            };

            var roles = (await _hrRepositoryManager.AuthRepository.GetRolesAsync(user))?.ToList();

            var userInfo = new UserInfoDto
            {
                Id = user.Id,
                UserName = user?.UserName,
                Email = user?.Email,
                AccessToken = GenerateJwtToken(user, roles),
                RefreshToken = refreshToken.Token,
                TokenExpiration = refreshToken.ExpiresOn,
                Roles = roles
            };

            user.RefreshTokens.Add(refreshToken);
            _hrRepositoryManager.AuthRepository.Update(user);
            await _hrRepositoryManager.UnitOfWork.SaveChangesAsync();

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

    }
}
