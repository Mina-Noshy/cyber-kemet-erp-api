using Kemet.ERP.Abstraction.IShared;
using Kemet.ERP.Contracts.HR.Common;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IEntity.HR.Common
{
    public interface IRegionService : ICRUDService<RegionDto>
    {
        Task<ApiResponse> GetAllAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
