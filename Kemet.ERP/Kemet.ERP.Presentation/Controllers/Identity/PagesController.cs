using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [Authorize]
    public class PagesController : BaseIdentityController
    {
        private readonly IPageMasterService _service;
        public PagesController(IPageMasterService service)
            => _service = service;




        [HttpGet("light/{menuId:long}")]
        public async Task<IActionResult> GetLightAsync(long menuId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(menuId, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-menu/{menuId:long}")]
        public async Task<IActionResult> GetAllByMenuIdAsync(long menuId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllByMenuIdAsync(menuId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PageMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, PageMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
