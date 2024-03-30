using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.HR.Common;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.HR.Common
{
    public interface IRegionService : ICRUDService<RegionDto>
    {
        Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
