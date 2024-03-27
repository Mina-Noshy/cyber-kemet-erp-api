using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IShared
{
    public interface IQueryService<T> where T : IDto
    {
        Task<ApiResponse> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    }
}
