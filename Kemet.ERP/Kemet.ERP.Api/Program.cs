
using Kemet.ERP.Api;
using Kemet.ERP.Api.Configurations;
using Kemet.ERP.Api.Logger;
using Kemet.ERP.Domain.Common.Utilities;
using Kemet.ERP.Persistence;
using Kemet.ERP.Services;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();
    ConfigurationHelper.Initialize(builder.Configuration);


    SerilogLogger.EnsureInitialized();
    Log.Information("Starting web host");

    builder.Host.UseSerilog();
    builder.Services.RegisterCommonServices();
    builder.Services.RegisterContexts();
    builder.Services.RegisterRepositories();
    builder.Services.RegisterServices();
    builder.Services.RegisterRateLimiter();
    builder.Services.RegisterCors();
    builder.Services.RegisterAuthentication();
    builder.Services.RegisterCommonServices();
    builder.Services.RegisterSwagger();



    var app = builder.Build();

    app.UsePipilines(app.Environment);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception :: RERA Api server start-up failed");
}
finally
{
    Log.Information("RERA Api server shutting down...");
    Log.CloseAndFlush();
}