using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.HR.Identity;
using Kemet.ERP.Presentation.Controllers.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR.Identity
{
    //[ApiKeyAuth]
    public class AccountsController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public AccountsController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;




        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.CreateUserAsync(request, cancellationToken));

        [HttpPost("get-users")]
        public async Task<IActionResult> GetUsersAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetUsersAsync(request.Skip, request.Take, cancellationToken));

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetUserByIdAsync(id, cancellationToken));

    }
}
