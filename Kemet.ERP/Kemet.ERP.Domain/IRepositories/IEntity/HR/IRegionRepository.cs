using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories.IShared;

namespace Kemet.ERP.Domain.IRepositories.IEntity.HR
{
    public interface IRegionRepository : ICRUDRepository<Region>
    {
        Task<IEnumerable<Region>> GetAllAsync(long countryId, CancellationToken cancellationToken = default);
    }
}
