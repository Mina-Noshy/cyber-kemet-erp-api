using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.HR.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kemet.ERP.Presentation.Controllers.HR.Common
{
    [Authorize]
    public class RegionsController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public RegionsController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;





        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-country/{countryId:long}")]
        public async Task<IActionResult> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllByCountryIdAsync(countryId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegionDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(RegionDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.DeleteAsync(id, cancellationToken));

    }
}
