using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Kemet.ERP.Presentation.Controllers.Master
{
    [Authorize]
    public class CitiesController : BaseMasterController
    {
        private readonly ICityMasterService _service;
        public CitiesController(ICityMasterService service)
            => _service = service;





        [HttpGet("light/{countryId:long}")]
        public async Task<IActionResult> GetLightAsync(long countryId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(countryId, cancellationToken));

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
        public async Task<IActionResult> CreateAsync(CityMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, CityMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
