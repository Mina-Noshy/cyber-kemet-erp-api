using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.Common;
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
        public async Task<IActionResult> CreateAsync(CreateUserDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.CreateAsync(request, cancellationToken));

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAllAsync(PaginationDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetAllAsync(request.Skip, request.Take, cancellationToken));

        [HttpGet("get-by-email/{email}")]
        public async Task<IActionResult> GetByEmailAsync(string email, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByEmailAsync(email, cancellationToken));

        [HttpGet("get-by-name/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByNameAsync(name, cancellationToken));

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AccountService.GetByIdAsync(id, cancellationToken));

    }
}
