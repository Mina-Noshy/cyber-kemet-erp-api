using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Shared;
using Kemet.ERP.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [ApiKeyAuth]
    public class AccountsController : BaseIdentityController
    {
        private readonly IIdentityServiceManager _serviceManager;
        public AccountsController(IIdentityServiceManager serviceManager)
            => _serviceManager = serviceManager;




        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AccountService.CreateUserAsync(request, cancellationToken));

        [HttpPost("get-users")]
        public async Task<IActionResult> GetUsersAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AccountService.GetUsersAsync(request.Skip, request.Take, cancellationToken));

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AccountService.GetUserByIdAsync(id, cancellationToken));

    }
}
