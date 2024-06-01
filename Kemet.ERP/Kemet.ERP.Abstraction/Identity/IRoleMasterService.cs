using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IRoleMasterService
    {
        Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> CreateAsync(RoleDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> UpdateAsync(string id, RoleDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);

    }
}
