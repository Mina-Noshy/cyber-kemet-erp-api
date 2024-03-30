using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Shared.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Text.Json;

namespace Kemet.ERP.Presentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private static readonly string API_KEY_1 = ConfigurationHelper.GetApiKeys("ApiKey1");
        private static readonly string RETURN_MSG = ConfigurationHelper.GetApiKeys("InvalidAPIKeyMsg");

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate _next)
        {
            string? apiKey = context.HttpContext.Request.Headers["apikey"];

            if (apiKey != null && apiKey == API_KEY_1)
            {
                await _next();
            }
            else
            {
                Log.Warning(RETURN_MSG);

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

                var response = new ApiResponse(false, RETURN_MSG);
                await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
    }
}
