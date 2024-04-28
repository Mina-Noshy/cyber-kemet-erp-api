using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Master
{
    public interface ICityMasterService : ICRUDService<CityMasterDto>
    {
        Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetLightAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
