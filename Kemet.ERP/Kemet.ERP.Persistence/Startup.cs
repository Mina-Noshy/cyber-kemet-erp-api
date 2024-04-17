using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.App;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Persistence.Contexts;
using Kemet.ERP.Persistence.Repositories;
using Kemet.ERP.Persistence.Repositories.App;
using Kemet.ERP.Persistence.Repositories.Identity;
using Kemet.ERP.Shared.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kemet.ERP.Persistence
{
    public static class Startup
    {

        public static IServiceCollection RegisterContexts(this IServiceCollection services)
        {
            services.AddDbContext<MainDbContext>(options =>
            {
                string connectionString = ConfigurationHelper.GetDbConn("KemetCS");

                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("Kemet.ERP.Api");
                    sqlServerOptions.CommandTimeout(600);
                });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Scoped);


            services.AddIdentity<AppUser, IdentityRole>(
            options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IMainDbContext, MainDbContext>();
            services.AddScoped<IDapperRepository, DapperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMemoryCacheRepository, MemoryCacheRepository>();
            services.AddScoped<IRequestHandlingRepository, RequestHandlingRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            return services;
        }
    }
}
