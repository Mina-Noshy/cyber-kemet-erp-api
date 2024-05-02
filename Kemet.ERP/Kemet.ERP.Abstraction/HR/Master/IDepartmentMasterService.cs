using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;

namespace Kemet.ERP.Abstraction.HR.Master
{
    public interface IDepartmentMasterService : ICRUDService<DepartmentMasterDto>
    {
        Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default);
    }
}
