using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Common
{
    public interface IQueryService<T> where T : IDto
    {
        Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
