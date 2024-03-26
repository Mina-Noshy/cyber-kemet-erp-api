using Kemet.ERP.Api.Middleware;
using Serilog;

namespace Kemet.ERP.Api.ManageExtensions
{
    public static class PiplineConfigurations
    {
        public static IApplicationBuilder UseAppPipilines(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger()
                .UseSwaggerUI();
            }
            else
            {
                app.UseSwagger()
                .UseSwaggerUI();
            }

            // Apply rate limiting
            app.UseRateLimiter()

            // Serve static files
            .UseStaticFiles()

            // Apply exception handling middleware
            .UseExceptionHandlingMiddleware()

            // Apply request handling middleware
            .UseRequestHandlingMiddleware()

            // Log requests using Serilog
            .UseSerilogRequestLogging()

            // Enable CORS
            .UseCors("AllowAll")

            // Redirect HTTP to HTTPS
            .UseHttpsRedirection()

            // Enable endpoint routing
            .UseRouting()

            // Authenticate users
            .UseAuthentication()

            // Authorize access
            .UseAuthorization()

            // Buffering
            .Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            })

            // Map controllers
            .UseEndpoints(endpoints => endpoints
                .MapControllers()
            );

            return app;
        }
    }
}
