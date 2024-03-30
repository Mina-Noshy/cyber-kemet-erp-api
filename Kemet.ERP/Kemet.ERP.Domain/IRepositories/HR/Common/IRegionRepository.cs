using Kemet.ERP.Domain.Entities.HR.Common;
using Kemet.ERP.Domain.IRepositories.Common;

namespace Kemet.ERP.Domain.IRepositories.HR.Common
{
    public interface IRegionRepository : ICRUDRepository<Region>
    {
        Task<IEnumerable<Region>> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
