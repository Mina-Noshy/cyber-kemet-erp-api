using Microsoft.Extensions.Configuration;

namespace Kemet.ERP.Shared.Utilities
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration;
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static string GetDbConn(string connName)
            => _configuration[$"ConnectionStrings:{connName}"] ?? string.Empty;

        public static string GetJWT(string key)
            => _configuration[$"JWT:{key}"] ?? string.Empty;

        public static string GetApiKeys(string key)
            => _configuration[$"ApiKeys:{key}"] ?? string.Empty;

        public static string GetSerilog(string key)
            => _configuration[$"Serilog:{key}"] ?? string.Empty;

        public static string GetRateLimiter(string key)
            => _configuration[$"RateLimiter:{key}"] ?? string.Empty;

        public static string GetSMTP(string key)
            => _configuration[$"SMTP:{key}"] ?? string.Empty;

        public static string GetURL(string key)
            => _configuration[$"URLs:{key}"] ?? string.Empty;

        public static string GetProfile(string key)
            => _configuration[$"Profile:{key}"] ?? string.Empty;

    }
}
