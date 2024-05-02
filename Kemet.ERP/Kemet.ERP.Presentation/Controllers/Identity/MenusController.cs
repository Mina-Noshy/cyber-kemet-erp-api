using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [Authorize]
    public class MenusController : BaseIdentityController
    {
        private readonly IMenuMasterService _service;
        public MenusController(IMenuMasterService service)
            => _service = service;



        [HttpGet("light/{moduleId:long}")]
        public async Task<IActionResult> GetLightAsync(long moduleId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(moduleId, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-module/{moduleId:long}")]
        public async Task<IActionResult> GetAllByModuleIdAsync(long moduleId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllByModuleIdAsync(moduleId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MenuMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, MenuMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
