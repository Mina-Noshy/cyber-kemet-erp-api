using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [Authorize]
    public class RolePagesController : BaseIdentityController
    {
        private readonly IRolePageMasterService _service;
        public RolePagesController(IRolePageMasterService service)
            => _service = service;




        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-role/{roleId}")]
        public async Task<IActionResult> GetAllByRoleIdAsync(string roleId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllByRoleIdAsync(roleId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RolePageMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, RolePageMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
