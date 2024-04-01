using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Abstraction.Shared
{
    public interface IQueryService<T> where T : IDto
    {
        Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
