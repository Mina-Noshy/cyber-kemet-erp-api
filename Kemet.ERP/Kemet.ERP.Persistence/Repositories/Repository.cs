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

        public async Task<T?> GetByIdAsync<T>(long id, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public IQueryable<T> GetAll<T>(params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate, params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params string[] includeProperties) where T : TEntity
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public void Add<T>(T entity) where T : TEntity
        {
            _context.Set<T>().Add(entity);
        }

        public async void AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : TEntity
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
        }

        public void Update<T>(T entity) where T : TEntity
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : TEntity
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public void Remove<T>(T entity) where T : TEntity
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : TEntity
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : TEntity
        {
            return await _context.Set<T>().CountAsync(predicate, cancellationToken);
        }

        public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : TEntity
        {
            return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
        }
    }
}
