using Kemet.ERP.Domain.Entities.Shared;
using System.Linq.Expressions;

namespace Kemet.ERP.Domain.IRepositories
{
    public interface IRepository
    {
        Task<T?> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity;
        IQueryable<T> GetAll<T>(params string[] includeProperties) where T : TEntity;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate, params string[] includeProperties) where T : TEntity;
        Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity;
        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity;
        Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity;
        void Add<T>(T entity) where T : TEntity;
        void AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : TEntity;
        void Update<T>(T entity) where T : TEntity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : TEntity;
        void Remove<T>(T entity) where T : TEntity;
        void RemoveRange<T>(IEnumerable<T> entities) where T : TEntity;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : TEntity;
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : TEntity;
    }

}
