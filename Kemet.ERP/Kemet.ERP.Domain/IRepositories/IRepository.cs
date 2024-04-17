using Kemet.ERP.Domain.Entities.Shared;
using System.Linq.Expressions;

namespace Kemet.ERP.Domain.IRepositories
{
    public interface IRepository
    {
        Task<IEnumerable<object>> GetDynamicAsync<T>(Expression<Func<T, bool>>? filterExpression,
            Expression<Func<T, object>> selectionExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            CancellationToken cancellationToken = default) where T : TEntity;

        Task<T?> GetByIdAsync<T>(long id,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity;

        IQueryable<T> GetAll<T>(Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            params string[] includeProperties) where T : TEntity;

        IQueryable<T> Find<T>(Expression<Func<T, bool>> filterExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            params string[] includeProperties) where T : TEntity;

        Task<IEnumerable<T>> GetAllAsync<T>(Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity;

        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> filterExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity;

        Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity;

        Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity;

        void Add<T>(T entity) where T : TEntity;

        Task AddRangeAsync<T>(IEnumerable<T> entities,
            CancellationToken cancellationToken = default) where T : TEntity;

        void Update<T>(T entity) where T : TEntity;

        void UpdateRange<T>(IEnumerable<T> entities) where T : TEntity;

        void Remove<T>(T entity) where T : TEntity;

        void RemoveRange<T>(IEnumerable<T> entities) where T : TEntity;

        Task<int> CountAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default) where T : TEntity;

        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default) where T : TEntity;
    }

}
