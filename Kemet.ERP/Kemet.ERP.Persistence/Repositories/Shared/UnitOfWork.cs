using Kemet.ERP.Domain.IRepositories.Shared;
using Kemet.ERP.Persistence.Contexts;

namespace Kemet.ERP.Persistence.Repositories.Shared
{
    internal sealed class UnitOfWork : IUnitOfWork
    {

        private readonly RepositoryDbContext _dbContext;

        public UnitOfWork(RepositoryDbContext dbContext)
            => _dbContext = dbContext;


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _dbContext.SaveChangesAsync(cancellationToken);

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Database.CommitTransactionAsync(cancellationToken);


        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Database.RollbackTransactionAsync(cancellationToken);

    }
}
