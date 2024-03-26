using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories.IEntity.HR;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Entity.HR
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CountryRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;


        public async Task<IEnumerable<Country>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
            => await _dbContext.Countries.OrderBy(x => x.EnName).Skip(skip).Take(take).ToListAsync(cancellationToken);

        public async Task<Country?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
