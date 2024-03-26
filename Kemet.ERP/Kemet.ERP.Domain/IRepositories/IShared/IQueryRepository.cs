using Kemet.ERP.Domain.Entities;

namespace Kemet.ERP.Domain.IRepositories.IShared
{
    public interface IQueryRepository<T> where T : TEntity
    {
        Task<IEnumerable<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
