using Kemet.ERP.Domain.Entities.Common;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface ICRUDRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : TEntity
    {
    }
}
