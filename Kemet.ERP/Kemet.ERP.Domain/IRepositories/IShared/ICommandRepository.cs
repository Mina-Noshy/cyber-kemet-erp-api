using Kemet.ERP.Domain.Entities;

namespace Kemet.ERP.Domain.IRepositories.IShared
{
    public interface ICommandRepository<T> where T : TEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
