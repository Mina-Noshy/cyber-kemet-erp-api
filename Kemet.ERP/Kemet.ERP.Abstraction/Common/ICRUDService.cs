using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Abstraction.Common
{
    public interface ICRUDService<T> : IQueryService<T>, ICommandService<T> where T : IDto
    {
    }
}
