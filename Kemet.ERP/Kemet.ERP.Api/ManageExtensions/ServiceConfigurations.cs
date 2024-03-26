using Kemet.ERP.Abstraction;
using Kemet.ERP.Api.Middleware;
using Kemet.ERP.Contracts.HttpResponse;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Persistence.Contexts;
using Kemet.ERP.Persistence.Repositories;
using Kemet.ERP.Services;
using Kemet.ERP.Shared.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;

namespace Kemet.ERP.Api.ManageExtensions
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            //<=*****************=> Common <=*****************=>//
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();


            services.AddScoped<RequestHandlingMiddleware>();
            services.AddTransient<ExceptionHandlingMiddleware>();



            //<=*****************=> Memory Cache <=*****************=>//
            services.AddMemoryCache();



            //<=*****************=> Rate Limiter <=*****************=>//
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = int.Parse(ConfigurationHelper.GetRateLimiter("Requests")),
                            QueueLimit = 0,
                            Window = TimeSpan.FromSeconds(int.Parse(ConfigurationHelper.GetRateLimiter("Duration")))
                        }));

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        var response = new ApiResponse(false, $"Too many requests. Please try again after {retryAfter.TotalSeconds} seconds(s).");
                        await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken: token);
                    }
                    else
                    {
                        var response = new ApiResponse(false, $"Too many requests. Please try again later.");
                        await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken: token);
                    }
                };
            });








            //<=*****************=> Cors <=*****************=>//
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });


            //<=*****************=> Databse Context <=*****************=>//
            services.AddDbContext<RepositoryDbContext>(options =>
            {
                string connectionString = ConfigurationHelper.GetDbConn("KemetCS");

                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("Kemet.ERP.Api");
                    sqlServerOptions.CommandTimeout(600);
                });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Scoped);

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<RepositoryDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IHRServiceManager, HRServiceManager>();
            services.AddScoped<IHRRepositoryManager, HRRepositoryManager>();





            //<=*****************=> Authentication <=*****************=>//
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    //ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = ConfigurationHelper.GetJWT("Audience"),
                    ValidIssuer = ConfigurationHelper.GetJWT("Issuer"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.GetJWT("Key")))
                };
            });





            //<=*****************=> Swagger <=*****************=>//
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kemet API",
                    Version = "v1",
                    Description = "This is an API for Kemet ERP.",
                    Contact = new OpenApiContact
                    {
                        Name = "Kemet",
                        Email = "info@cyberkemet.com",
                        Url = new Uri("https://cyberkemet.com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Contact",
                        Url = new Uri("https://cyberkemet.com/")
                    }
                });

                // Include XML comments.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


                // Define the API key as a default header.
                c.AddSecurityDefinition("APIKey", new OpenApiSecurityScheme
                {
                    Name = "apikey",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "API Key authentication in the header using the Bearer scheme."
                });


                // Define Bearer token authentication.
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });


                // Define the DB key as a default header.
                c.AddSecurityDefinition("DB", new OpenApiSecurityScheme
                {
                    Name = "db",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Append DB value in header to all requests."
                });


                // Define the Lang key as a default header.
                c.AddSecurityDefinition("Language", new OpenApiSecurityScheme
                {
                    Name = "lang",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Append Lang value in header to all requests."
                });

                // Apply the requirement to all endpoints by adding it to the global security requirements.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "APIKey" }
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "DB" }
                        },
                        new string[] {}
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Language" }
                        },
                        new string[] {}
                    },
                });
            });

            services.Configure<SwaggerUIOptions>(c =>
            {
                c.HeadContent = @"<div style=""text-align: center; padding: 10px;""> </div>";
            });





            return services;
        }
    }
}
