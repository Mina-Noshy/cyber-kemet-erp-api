using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Abstraction
{
    public interface ICRUDService<T> : IQueryService<T>, ICommandService<T> where T : IDto
    {
    }
}
