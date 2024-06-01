using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [Authorize]
    public class RolesController : BaseIdentityController
    {
        private readonly IRoleMasterService _service;
        public RolesController(IRoleMasterService service)
            => _service = service;



        [HttpGet("light")]
        public async Task<IActionResult> GetLightAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetRolesAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(RoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, RoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(string id, CancellationToken cancellationToken)
           => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
