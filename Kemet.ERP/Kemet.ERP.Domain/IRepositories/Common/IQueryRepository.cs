using Kemet.ERP.Domain.Entities.Common;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface IQueryRepository<T> where T : TEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
