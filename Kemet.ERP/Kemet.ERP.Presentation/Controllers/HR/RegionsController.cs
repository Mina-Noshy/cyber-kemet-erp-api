using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts;
using Kemet.ERP.Presentation.Attributes;
using Kemet.ERP.Presentation.Controllers.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR
{
    [ApiKeyAuth]
    public class RegionsController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public RegionsController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;



        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(PaginationDto dto, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllAsync(dto, cancellationToken));

        [HttpPost("get-country-regions/{countryId:long}")]
        public async Task<IActionResult> GetAll(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetAllAsync(countryId, cancellationToken));

        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.RegionService.GetByIdAsync(id, cancellationToken));

    }
}
