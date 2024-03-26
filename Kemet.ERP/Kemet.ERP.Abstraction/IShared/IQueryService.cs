using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IShared
{
    public interface IQueryService<T> where T : IDto
    {
        Task<ApiResponse> GetAllAsync(PaginationDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
