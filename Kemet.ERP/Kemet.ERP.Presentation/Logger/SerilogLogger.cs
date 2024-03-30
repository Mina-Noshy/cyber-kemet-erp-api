using Kemet.ERP.Shared.Utilities;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

namespace Kemet.ERP.Presentation.Logger
{
    public static class SerilogLogger
    {
        public static void EnsureInitialized()
        {
            string filePath = ConfigurationHelper.GetSerilog("path")
                .Replace("{date}", DateTime.Now.ToString("yyyyMMddHHmmss"));

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new JsonFormatter())
                .WriteTo.File(new JsonFormatter(), filePath)
                .WriteTo.MSSqlServer(ConfigurationHelper.GetSerilog("connectionString"),
                            new MSSqlServerSinkOptions
                            {
                                TableName = ConfigurationHelper.GetSerilog("tableName"),
                                SchemaName = ConfigurationHelper.GetSerilog("schemaName"),
                                AutoCreateSqlTable = bool.Parse(ConfigurationHelper.GetSerilog("autoCreateSqlTable"))
                            })
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .CreateLogger();
        }
    }
}
