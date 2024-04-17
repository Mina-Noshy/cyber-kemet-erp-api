using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IAccountService
    {
        Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> ConfirmEmailAsync(string userId, string token, CancellationToken cancellationToken = default);
        Task<ApiResponse> SendConfirmationEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
