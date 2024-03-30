using Kemet.ERP.Domain.Entities.Common;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface ICommandRepository<T> where T : TEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
