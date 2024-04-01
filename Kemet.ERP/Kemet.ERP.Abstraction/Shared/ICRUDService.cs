using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Abstraction.Shared
{
    public interface ICRUDService<T> : IQueryService<T>, ICommandService<T> where T : IDto
    {
    }
}
