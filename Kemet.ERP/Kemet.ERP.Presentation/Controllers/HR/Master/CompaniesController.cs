﻿using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Contracts.HR.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR.Master
{
    [Authorize]
    public class CompaniesController : BaseHrController
    {
        private readonly ICompanyMasterService _service;
        public CompaniesController(ICompanyMasterService service)
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
        public async Task<IActionResult> CreateAsync([FromForm] CreateCompanyMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] CreateCompanyMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
