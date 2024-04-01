using Kemet.ERP.Abstraction.Shared;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Common
{
    public interface IRegionMasterService : ICRUDService<RegionMasterDto>
    {
        Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
