using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IEntity.HR
{
    public interface IAuthService
    {
        Task<ApiResponse> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken = default);
    }
}
