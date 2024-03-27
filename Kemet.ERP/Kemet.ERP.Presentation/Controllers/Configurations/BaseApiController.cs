using Kemet.ERP.Contracts.HttpResponse;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Configurations
{
    [ApiController]
    [Produces("application/json")]
    public class BaseApiController : ControllerBase
    {
        internal protected ActionResult FormatHttpResponse(ApiResponse response)
            => response.status ? Ok(response) : BadRequest(response);
    }
}
