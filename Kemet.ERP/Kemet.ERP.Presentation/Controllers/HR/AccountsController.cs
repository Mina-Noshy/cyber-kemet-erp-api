﻿using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Presentation.Attributes;
using Kemet.ERP.Presentation.Controllers.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR
{
    [ApiKeyAuth]
    public class AccountsController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public AccountsController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;




        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.CreateAsync(request, cancellationToken));

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetAllAsync(request, cancellationToken));

        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByEmailAsync(email, cancellationToken));

        [HttpGet("get-by-name/{name}")]
        public async Task<IActionResult> GetByName(string name, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByNameAsync(name, cancellationToken));

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByIdAsync(id, cancellationToken));

    }
}
