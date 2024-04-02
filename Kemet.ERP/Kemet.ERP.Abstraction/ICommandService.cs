using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Abstraction
{
    public interface ICommandService<T> where T : IDto
    {
        Task<ApiResponse> CreateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> UpdateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
