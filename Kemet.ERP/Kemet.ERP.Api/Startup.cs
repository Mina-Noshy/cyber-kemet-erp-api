using Kemet.ERP.Api.Middleware;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Shared.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.RateLimiting;

namespace Kemet.ERP.Api
{
    public static class Startup
    {
        public static IServiceCollection RegisterRateLimiter(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection RegisterCors(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ConfigurationHelper.GetJWT("Issuer"),
                    ValidAudience = ConfigurationHelper.GetJWT("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.GetJWT("Key")))
                };
            });

            return services;
        }

        public static IServiceCollection RegisterCommonServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddMemoryCache();
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();


            services.AddScoped<RequestHandlingMiddleware>();
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
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





        public static IApplicationBuilder UseAppPipilines(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger()
                .UseSwaggerUI();
            }
            else
            {
                app.UseSwagger()
                .UseSwaggerUI();
            }

            // Apply rate limiting
            app.UseRateLimiter()

            // Serve static files
            .UseStaticFiles()

            // Apply exception handling middleware
            .UseExceptionHandlingMiddleware()

            // Apply request handling middleware
            .UseRequestHandlingMiddleware()

            // Log requests using Serilog
            .UseSerilogRequestLogging()

            // Enable CORS
            .UseCors("AllowAll")

            // Redirect HTTP to HTTPS
            .UseHttpsRedirection()

            // Enable endpoint routing
            .UseRouting()

            // Authenticate users
            .UseAuthentication()

            // Authorize access
            .UseAuthorization()

            // Buffering
            .Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            })

            // Map controllers
            .UseEndpoints(endpoints => endpoints
                .MapControllers()
            );

            return app;
        }


    }
}
