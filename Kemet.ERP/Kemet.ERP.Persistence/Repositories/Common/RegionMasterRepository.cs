using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Common
{
    internal class RegionMasterRepository : IRegionMasterRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public RegionMasterRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;




        public async Task<IEnumerable<RegionMaster>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.RegionMaster.OrderBy(x => x.EnName).ToListAsync(cancellationToken);

        public async Task<IEnumerable<RegionMaster>> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
            => await _dbContext.RegionMaster
            .Where(x => x.CountryId == countryId)
            .OrderBy(x => x.EnName)
            .ToListAsync(cancellationToken);

        public async Task<RegionMaster?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.RegionMaster.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Create(RegionMaster entity)
            => _dbContext.RegionMaster.Add(entity);

        public void Update(RegionMaster entity)
            => _dbContext.RegionMaster.Update(entity);

        public void Delete(RegionMaster entity)
            => _dbContext.RegionMaster.Remove(entity);
    }
}
