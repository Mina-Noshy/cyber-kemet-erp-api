using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Services.App;
using Kemet.ERP.Services.Identity;
using Kemet.ERP.Services.Master;
using Microsoft.Extensions.DependencyInjection;

namespace Kemet.ERP.Services
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
            services.AddScoped<IRequestHandlingService, RequestHandlingService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ICountryMasterService, CountryMasterService>();
            services.AddScoped<ICityMasterService, CityMasterService>();

            services.AddScoped<IBankMasterService, BankMasterService>();
            services.AddScoped<ICurrencyMasterService, CurrencyMasterService>();

            return services;
        }
    }
}
