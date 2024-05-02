using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.HR.Master
{
    public interface IJobTitleMasterService : ICRUDService<JobTitleMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
