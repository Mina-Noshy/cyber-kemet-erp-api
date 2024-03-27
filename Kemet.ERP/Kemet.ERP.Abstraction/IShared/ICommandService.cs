using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IShared
{
    public interface ICommandService<T> where T : IDto
    {
        Task<ApiResponse> CreateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> UpdateAsync(T request, CancellationToken cancellationToken = default);
        Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
