using Kemet.ERP.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
        internal protected ActionResult FormatHttpResponse(ApiResponse response)
            => Ok(response);
    }
}
