using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Common
{
    [Authorize]
    public class CountriesController : BaseCommonController
    {
        private readonly ICommonServiceManager _serviceManager;
        public CountriesController(ICommonServiceManager serviceManager)
            => _serviceManager = serviceManager;




        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.CountryMasterService.GetAllAsync(cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.CountryMasterService.GetByIdAsync(id, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CountryMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.CountryMasterService.CreateAsync(request, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CountryMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.CountryMasterService.UpdateAsync(request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.CountryMasterService.DeleteAsync(id, cancellationToken));

    }
}
