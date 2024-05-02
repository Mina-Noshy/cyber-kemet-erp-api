using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Master
{
    public interface IBankMasterService : ICRUDService<BankMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
