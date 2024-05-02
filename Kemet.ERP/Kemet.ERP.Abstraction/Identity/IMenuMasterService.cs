using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IMenuMasterService : ICRUDService<MenuMasterDto>
    {
        Task<ApiResponse> GetAllByModuleIdAsync(long moduleId, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetLightAsync(long moduleId, CancellationToken cancellationToken = default);
    }
}
