using Kemet.ERP.Domain.Entities.HR.Common;
using Kemet.ERP.Domain.IRepositories.IShared;

namespace Kemet.ERP.Domain.IRepositories.IEntity.HR.Common
{
    public interface IRegionRepository : ICRUDRepository<Region>
    {
        Task<IEnumerable<Region>> GetAllAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
