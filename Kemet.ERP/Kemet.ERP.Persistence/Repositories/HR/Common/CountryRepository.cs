using Kemet.ERP.Domain.Entities.HR.Common;
using Kemet.ERP.Domain.IRepositories.HR.Common;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.HR.Common
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public CountryRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;




        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Countries.OrderBy(x => x.EnName).ToListAsync(cancellationToken);

        public async Task<Country?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Create(Country entity)
            => _dbContext.Countries.Add(entity);

        public void Update(Country entity)
            => _dbContext.Countries.Update(entity);

        public void Delete(Country entity)
            => _dbContext.Countries.Remove(entity);

    }
}
