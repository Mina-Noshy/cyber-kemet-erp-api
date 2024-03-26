using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IEntity.HR
{
    public interface IAccountService
    {
        Task<ApiResponse> GetAllAsync(PaginationDto request, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<ApiResponse> CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default);
    }
}
