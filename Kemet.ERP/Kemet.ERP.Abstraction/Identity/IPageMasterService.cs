using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IPageMasterService : ICRUDService<PageMasterDto>
    {
        Task<ApiResponse> GetAllByMenuIdAsync(long menuId, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetLightAsync(long menuId, CancellationToken cancellationToken = default);
    }
}
