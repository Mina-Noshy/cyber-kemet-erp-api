﻿using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Contracts.HR.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR.Master
{
    [Authorize]
    public class BranchesController : BaseHrController
    {
        private readonly IBranchMasterService _service;
        public BranchesController(IBranchMasterService service)
            => _service = service;




        [HttpGet("light/{companyId:long}")]
        public async Task<IActionResult> GetLightAsync(long companyId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetLightAsync(companyId, cancellationToken));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllAsync(cancellationToken));

        [HttpGet("by-company/{companyId:long}")]
        public async Task<IActionResult> GetAllByCompanyIdAsync(long companyId, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetAllByCompanyIdAsync(companyId, cancellationToken));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetByIdAsync(id, cancellationToken));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BranchMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, BranchMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}