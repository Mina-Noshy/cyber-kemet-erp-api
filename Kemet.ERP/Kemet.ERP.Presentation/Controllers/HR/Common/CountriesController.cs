using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.HR.Common;
using Kemet.ERP.Presentation.Controllers.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR.Common
{
    [Authorize]
    public class CountriesController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public CountriesController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;




        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.GetAllAsync(request.Skip, request.Take, cancellationToken));

        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.GetByIdAsync(id, cancellationToken));




        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CountryDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.CreateAsync(request, cancellationToken));

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(CountryDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.UpdateAsync(request, cancellationToken));

        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.DeleteAsync(id, cancellationToken));

    }
}
