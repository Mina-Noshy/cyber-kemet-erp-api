using Kemet.ERP.Domain.Entities.HR.Common;
using Kemet.ERP.Domain.IRepositories.HR.Common;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.HR.Common
{
    internal class RegionRepository : IRegionRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public RegionRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;




        public async Task<IEnumerable<Region>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Regions.OrderBy(x => x.EnName).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Region>> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
            => await _dbContext.Regions
            .Where(x => x.CountryId == countryId)
            .OrderBy(x => x.EnName)
            .ToListAsync(cancellationToken);

        public async Task<Region?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Create(Region entity)
            => _dbContext.Regions.Add(entity);

        public void Update(Region entity)
            => _dbContext.Regions.Update(entity);

        public void Delete(Region entity)
            => _dbContext.Regions.Remove(entity);
    }
}
