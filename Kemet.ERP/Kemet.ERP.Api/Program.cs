
using Kemet.ERP.Api.Configurations;
using Kemet.ERP.Api.ManageExtensions;
using Kemet.ERP.Presentation.Logger;
using Kemet.ERP.Shared.Utilities;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();
    ConfigurationHelper.Initialize(builder.Configuration);


    SerilogLogger.EnsureInitialized();
    Log.Information("Starting web host");

    builder.Host.UseSerilog();
    builder.Services.AddAppServices();




    var app = builder.Build();

    app.UseAppPipilines(app.Environment);

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