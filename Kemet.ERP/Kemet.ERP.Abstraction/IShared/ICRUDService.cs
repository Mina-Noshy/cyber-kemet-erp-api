using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Abstraction.IShared
{
    public interface ICRUDService<T> : IQueryService<T>, ICommandService<T> where T : IDto
    {
    }
}
