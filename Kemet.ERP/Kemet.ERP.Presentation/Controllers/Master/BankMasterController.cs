﻿using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Master
{
    [Authorize]
    public class BankMasterController : BaseMasterController
    {
        private readonly IBankMasterService _service;
        public BankMasterController(IBankMasterService service)
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
        public async Task<IActionResult> CreateAsync(BankMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateAsync(request, cancellationToken));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, BankMasterDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.UpdateAsync(id, request, cancellationToken));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.DeleteAsync(id, cancellationToken));

    }
}
