using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Presentation.Controllers.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kemet.ERP.Presentation.Controllers.HR
{
    [Authorize]
    public class RegionsController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public RegionsController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;





        [HttpGet("get-all/{countryId:long}")]
        public async Task<IActionResult> GetAllAsync(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllAsync(countryId, cancellationToken));

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllAsync(request.Skip, request.Take, cancellationToken));

        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetByIdAsync(id, cancellationToken));




        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(RegionDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.CreateAsync(request, cancellationToken));

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(RegionDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.UpdateAsync(request, cancellationToken));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.DeleteAsync(id, cancellationToken));

    }
}
