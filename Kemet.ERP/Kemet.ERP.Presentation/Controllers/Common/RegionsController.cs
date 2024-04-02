using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kemet.ERP.Presentation.Controllers.Common
{
    [Authorize]
    public class RegionsController : BaseCommonController
    {
        private readonly IRegionMasterService _service;
        public RegionsController(IRegionMasterService service)
            => _service = service;





        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-country/{countryId:long}")]
        public async Task<IActionResult> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllByCountryIdAsync(countryId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegionMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(RegionMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
