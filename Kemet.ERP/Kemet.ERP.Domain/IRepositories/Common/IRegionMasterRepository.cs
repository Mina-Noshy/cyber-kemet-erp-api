using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.IRepositories.Shared;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface IRegionMasterRepository : ICRUDRepository<RegionMaster>
    {
        Task<IEnumerable<RegionMaster>> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
