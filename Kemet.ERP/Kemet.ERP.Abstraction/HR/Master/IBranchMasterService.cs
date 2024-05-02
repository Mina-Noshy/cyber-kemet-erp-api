using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.HR.Master
{
    public interface IBranchMasterService : ICRUDService<BranchMasterDto>
    {
        Task<ApiResponse> GetAllByCompanyIdAsync(long companyId, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetLightAsync(long companyId, CancellationToken cancellationToken = default);
    }
}
