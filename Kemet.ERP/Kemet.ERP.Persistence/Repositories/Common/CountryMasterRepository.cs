using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Common
{
    internal class CountryMasterRepository : ICountryMasterRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public CountryMasterRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;




        public async Task<IEnumerable<CountryMaster>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.CountryMaster.OrderBy(x => x.EnName).ToListAsync(cancellationToken);

        public async Task<CountryMaster?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.CountryMaster.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void Create(CountryMaster entity)
            => _dbContext.CountryMaster.Add(entity);

        public void Update(CountryMaster entity)
            => _dbContext.CountryMaster.Update(entity);

        public void Delete(CountryMaster entity)
            => _dbContext.CountryMaster.Remove(entity);

    }
}
