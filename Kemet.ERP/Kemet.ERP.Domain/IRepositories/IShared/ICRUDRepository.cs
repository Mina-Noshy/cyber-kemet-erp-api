using Kemet.ERP.Domain.Entities;

namespace Kemet.ERP.Domain.IRepositories.IShared
{
    public interface ICRUDRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : TEntity
    {
    }
}
