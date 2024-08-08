using Kemet.ERP.Domain.Entities.Shared;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kemet.ERP.Persistence.Repositories
{
    public class Repository : IRepository
    {
        private readonly IMainDbContext _context;
        public Repository(IMainDbContext context)
            => _context = context;


        public async Task<IEnumerable<object>> GetDynamicAsync<T>(Expression<Func<T, bool>>? filterExpression,
            Expression<Func<T, object>> selectionExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            CancellationToken cancellationToken = default) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();

            // Apply filterExpression if provided
            if (filterExpression != null)
                query = query.Where(filterExpression);

            // Apply additional conditions for IsDeleted
            query = query.Where(x => x.IsDeleted == false);

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Select only the required properties
            var selectedQuery = query.Select(selectionExpression);

            return await selectedQuery.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TProjection>> GetDynamicAsync<T, TProjection>(Expression<Func<T, bool>>? filterExpression,
            Expression<Func<T, TProjection>> selectionExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            CancellationToken cancellationToken = default) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();

            // Apply filterExpression if provided
            if (filterExpression != null)
                query = query.Where(filterExpression);

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Select only the required properties
            var selectedQuery = query.Select(selectionExpression);

            // Apply skip and take
            return await selectedQuery.Distinct().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync<T>(long id,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false, cancellationToken);
        }

        public IQueryable<T> GetAll<T>(Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(x => x.IsDeleted == false);

            // Include properties
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Apply skip and take
            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return query;
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> filterExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(filterExpression);

            // Apply additional conditions for IsDeleted
            query = query.Where(x => x.IsDeleted == false);

            // Include properties
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Apply skip and take
            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return query;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(x => x.IsDeleted == false);

            // Include properties
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Apply skip and take
            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> filterExpression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderByExpression = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(filterExpression);

            // Apply additional conditions for IsDeleted
            query = query.Where(x => x.IsDeleted == false);

            // Include properties
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            // Apply orderByExpression if provided
            if (orderByExpression != null)
                query = orderByExpression(query);

            // Apply skip and take
            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(filterExpression);

            // Apply additional conditions for IsDeleted
            query = query.Where(x => x.IsDeleted == false);

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(filterExpression);

            // Apply additional conditions for IsDeleted
            query = query.Where(x => x.IsDeleted == false);

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public void Add<T>(T entity) where T : TEntity
        {
            _context.Set<T>().Add(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities,
            CancellationToken cancellationToken = default) where T : TEntity
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public void Update<T>(T entity) where T : TEntity
        {
            if (entity.Id < 1)
                return;

            _context.Set<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : TEntity
        {
            foreach (var item in entities)
            {
                if (item.Id < 1)
                    return;
            }

            _context.Set<T>().UpdateRange(entities);
        }

        public void Remove<T>(T entity) where T : TEntity
        {
            entity.IsDeleted = true;
            Update<T>(entity);

            //_context.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : TEntity
        {
            foreach (var item in entities)
            {
                item.IsDeleted = true;
            }
            UpdateRange<T>(entities);

            //_context.Set<T>().RemoveRange(entities);
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken = default) where T : TEntity
        {
            return await _context.Set<T>().CountAsync(filterExpression, cancellationToken);
        }

        public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default) where T : TEntity
        {
            return await _context.Set<T>().AnyAsync(filterExpression, cancellationToken);
        }

    }
}
