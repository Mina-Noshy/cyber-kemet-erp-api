using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IModuleMasterService : ICRUDService<ModuleMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
