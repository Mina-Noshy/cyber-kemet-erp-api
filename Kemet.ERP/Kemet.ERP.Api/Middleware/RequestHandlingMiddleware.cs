using Kemet.ERP.Shared.Constants;
using System.Security.Claims;

namespace Kemet.ERP.Api.Middleware
{
    internal sealed class RequestHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Skip all identity requests.
            // Means set the base db for all identity requests.
            // And get db name from request header if the request not going to identity module.
            if (context.Request.Path.StartsWithSegments("/api/identity"))
                context.Items[HttpContextKeys.DB] = null;
            else
                context.Items[HttpContextKeys.DB] = context.Request.Headers[HttpContextKeys.DB];

            // User info.
            context.Items[HttpContextKeys.USER_ID] = context?.User?.FindFirstValue(HttpContextKeys.USER_ID)?.ToString() ?? string.Empty;
            context.Items[HttpContextKeys.COMPANY_ID] = context?.User?.FindFirstValue(HttpContextKeys.COMPANY_ID)?.ToString() ?? string.Empty;
            context.Items[HttpContextKeys.COMPANY_NO] = context?.User?.FindFirstValue(HttpContextKeys.COMPANY_NO)?.ToString() ?? string.Empty;

            // Device info. 
            context.Items[HttpContextKeys.USER_AGENT] = context.Request.Headers["User-Agent"].ToString();
            context.Items[HttpContextKeys.USER_IP] = context.Connection?.RemoteIpAddress?.ToString();

            // Language.
            context.Items[HttpContextKeys.LANG] = context.Request.Headers[HttpContextKeys.LANG];

            await next(context);
        }

    }

    public static class RequestHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHandlingMiddleware>();
        }
    }
}
