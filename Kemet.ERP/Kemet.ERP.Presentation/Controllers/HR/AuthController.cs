using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Presentation.Attributes;
using Kemet.ERP.Presentation.Controllers.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR
{
    [ApiKeyAuth]
    public class AuthController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public AuthController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;



        [HttpPost("get-token")]
        public async Task<IActionResult> GetToken(GetTokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.GetTokenAsync(request, cancellationToken));

    }
}
