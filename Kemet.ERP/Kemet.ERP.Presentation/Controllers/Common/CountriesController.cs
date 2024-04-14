using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Common
{
    [Authorize]
    public class CountriesController : BaseCommonController
    {
        private readonly ICountryMasterService _service;
        public CountriesController(ICountryMasterService service)
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
        public async Task<IActionResult> CreateAsync(CountryMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CountryMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
