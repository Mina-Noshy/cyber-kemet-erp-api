using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.IRepositories.Shared
{
    public interface ICRUDRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : TEntity
    {
    }
}
