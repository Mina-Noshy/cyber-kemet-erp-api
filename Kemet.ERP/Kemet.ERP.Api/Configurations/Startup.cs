namespace Kemet.ERP.Api.Configurations
{
    public static class Startup
    {
        public static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                const string configurationsDirectory = "Configurations";
                var env = context.HostingEnvironment;
                config
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/database.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/database.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/jwt.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/jwt.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/logger.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/apikeys.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/apikeys.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/ratelimiter.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/ratelimiter.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/smtp.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/smtp.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/url.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/url.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/profile.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/profile.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/en.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/en.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddJsonFile($"{configurationsDirectory}/ar.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/ar.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                    .AddEnvironmentVariables();
            });

            return builder;
        }
    }
}
