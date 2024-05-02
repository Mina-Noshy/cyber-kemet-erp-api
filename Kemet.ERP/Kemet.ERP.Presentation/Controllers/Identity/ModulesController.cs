using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [Authorize]
    public class ModulesController : BaseIdentityController
    {
        private readonly IModuleMasterService _service;
        public ModulesController(IModuleMasterService service)
            => _service = service;




        [HttpGet("light")]
        public async Task<IActionResult> GetLightAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ModuleMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, ModuleMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
