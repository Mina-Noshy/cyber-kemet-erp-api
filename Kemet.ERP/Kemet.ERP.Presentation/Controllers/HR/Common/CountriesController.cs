using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.HR.Common;
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




        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.GetByIdAsync(id, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CountryDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CountryDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.CountryService.DeleteAsync(id, cancellationToken));

    }
}
