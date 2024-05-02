using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Services.App;
using Kemet.ERP.Services.HR.Master;
using Kemet.ERP.Services.Identity;
using Kemet.ERP.Services.Master;
using Microsoft.Extensions.DependencyInjection;

namespace Kemet.ERP.Services
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region App Services

            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
            services.AddScoped<IRequestHandlingService, RequestHandlingService>();

            #endregion

            #region Identity Services
            // Base
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();

            // Permissions
            services.AddScoped<IModuleMasterService, ModuleMasterService>();
            services.AddScoped<IMenuMasterService, MenuMasterService>();
            services.AddScoped<IPageMasterService, PageMasterService>();
            services.AddScoped<IRolePageMasterService, RolePageMasterService>();

            #endregion

            #region Master Services

            services.AddScoped<ICountryMasterService, CountryMasterService>();
            services.AddScoped<ICityMasterService, CityMasterService>();

            services.AddScoped<IBankMasterService, BankMasterService>();
            services.AddScoped<ICurrencyMasterService, CurrencyMasterService>();

            #endregion

            #region HR Services

            // Master
            services.AddScoped<ICompanyMasterService, CompanyMasterService>();
            services.AddScoped<IBranchMasterService, BranchMasterService>();

            services.AddScoped<IDepartmentMasterService, DepartmentMasterService>();
            services.AddScoped<IJobTitleMasterService, JobTitleMasterService>();

            services.AddScoped<IEmploymentStatusMasterService, EmploymentStatusMasterService>();
            services.AddScoped<IEmploymentTypeMasterService, EmploymentTypeMasterService>();

            // HR Database

            #endregion



            return services;
        }
    }
}
