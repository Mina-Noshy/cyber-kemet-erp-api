﻿using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{

    public class AccountsController : BaseIdentityController
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
            => _service = service;



        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.CreateUserAsync(request, cancellationToken));

        [Authorize]
        [HttpPost("get-users")]
        public async Task<IActionResult> GetUsersAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetUsersAsync(request.Skip, request.Take, cancellationToken));

        [Authorize]
        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetUserByIdAsync(id, cancellationToken));

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync(string userId, string token, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.ConfirmEmailAsync(userId, token, cancellationToken));

        [HttpPost("send-confirmation-email/{email}")]
        public async Task<IActionResult> SendConfirmationEmailAsync(string email, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.SendConfirmationEmailAsync(email, cancellationToken));

    }
}
