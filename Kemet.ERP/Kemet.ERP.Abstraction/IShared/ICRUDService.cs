using Kemet.ERP.Contracts;

namespace Kemet.ERP.Abstraction.IShared
{
    public interface ICRUDService<T> : IQueryService<T>, ICommandService<T> where T : IDto
    {
    }
}
