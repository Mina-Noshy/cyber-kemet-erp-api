using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IRolePageMasterService : ICRUDService<RolePageMasterDto>
    {
        Task<ApiResponse> GetAllByRoleIdAsync(string roleId, CancellationToken cancellationToken = default);
    }
}
