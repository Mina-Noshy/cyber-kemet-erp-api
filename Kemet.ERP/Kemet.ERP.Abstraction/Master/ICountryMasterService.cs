using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Master
{
    public interface ICountryMasterService : ICRUDService<CountryMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
