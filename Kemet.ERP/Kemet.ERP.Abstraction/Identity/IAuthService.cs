using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IAuthService
    {
        Task<ApiResponse> GetRolesAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<ApiResponse> CreateRoleAsync(string role, CancellationToken cancellationToken = default);
        Task<ApiResponse> DeleteRoleAsync(string role, CancellationToken cancellationToken = default);

        Task<ApiResponse> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken = default);


        Task<ApiResponse> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> RevokeTokenAsync(TokenDto request, CancellationToken cancellationToken = default);

        Task<ApiResponse> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken = default);
    }
}
