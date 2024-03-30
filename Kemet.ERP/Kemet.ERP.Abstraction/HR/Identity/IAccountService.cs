using Kemet.ERP.Contracts.HR.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.HR.Identity
{
    public interface IAccountService
    {
        Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default);
    }
}
