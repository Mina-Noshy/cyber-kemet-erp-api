using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.Common
{
    public interface ICommandService<T> where T : IDto
    {
        Task<ApiResponse> CreateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> UpdateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
