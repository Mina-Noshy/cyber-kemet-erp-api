using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Services.App;
using Kemet.ERP.Services.Common;
using Kemet.ERP.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kemet.ERP.Services
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            // Services
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
            services.AddScoped<IRequestHandlingService, RequestHandlingService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ICountryMasterService, CountryMasterService>();
            services.AddScoped<IRegionMasterService, RegionMasterService>();

            return services;
        }
    }
}
