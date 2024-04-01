using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kemet.ERP.Presentation.Controllers.Common
{
    [Authorize]
    public class RegionsController : BaseCommonController
    {
        private readonly ICommonServiceManager _serviceManager;
        public RegionsController(ICommonServiceManager serviceManager)
            => _serviceManager = serviceManager;





        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.GetByIdAsync(id, cancellationToken));

        [HttpGet("by-country/{countryId:long}")]
        public async Task<IActionResult> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.GetAllByCountryIdAsync(countryId, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegionMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(RegionMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.RegionMasterService.DeleteAsync(id, cancellationToken));

    }
}
