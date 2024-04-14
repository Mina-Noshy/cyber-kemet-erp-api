using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Common
{
    public interface ICountryMasterService : ICRUDService<CountryMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
