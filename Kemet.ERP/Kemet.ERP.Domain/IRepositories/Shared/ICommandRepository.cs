using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.IRepositories.Shared
{
    public interface ICommandRepository<T> where T : TEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
