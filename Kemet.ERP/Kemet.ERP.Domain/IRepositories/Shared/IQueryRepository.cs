using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.IRepositories.Shared
{
    public interface IQueryRepository<T> where T : TEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
