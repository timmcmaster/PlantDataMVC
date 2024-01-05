using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PlantDataMVC.Api.Models.Mappers;
using PlantDataMVC.Constants;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.DependencyInjection;
using PlantDataMVC.Api.Helpers;
using Serilog;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace PlantDataMVC.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            // In ASP.NET Core 3.x, using `Host.CreateDefaultBuilder` (as in the preceding Program.cs snippet) will
            // set up some configuration for you based on your appsettings.json and environment variables. See "Remarks" at
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder for details.
            this.Configuration = configuration;
        }

        // ConfigureServices is where you register dependencies.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            });

            // 1. Identity Server setup 
            services.AddMvcCore();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(AuthorizationPolicies.RequireReadUserRole, policy =>
            //    {
            //        policy.RequireRole(AuthorizationRole.WebReadUser);
            //    });
            //    options.AddPolicy(AuthorizationPolicies.RequireWriteUserRole, policy =>
            //    {
            //        policy.RequireRole(AuthorizationRole.WebWriteUser);
            //    });
            //    options.AddPolicy(AuthorizationPolicies.RequireAdminUserRole, policy =>
            //    {
            //        policy.RequireRole(AuthorizationRole.WebAdminUser);
            //    });
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = PlantDataMvcConstants.IdSrvBase;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        // it's recommended to check the type header to avoid "JWT confusion" attacks
                        ValidTypes = new[] { "at+jwt" }

                    };
                });

            // Enable Cross-origin resource sharing if browser client on different domain to API and using AJAX calls
            // This can be set here or at controller or method level
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Add .Net Core api versioning
            // Example: https://code-maze.com/aspnetcore-api-versioning/
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddResponseCaching();

            // Acts as follows:
            // - if config action provided
            //      - use that as options for configuring
            // - if assemblies or marker types provided
            //      - Set mapperConfigurationOptions to add maps from assemblies 
            //      - Adds all types from assemblies implementing:
            //          IValueResolver<,,>,
            //          IMemberValueResolver<,,,>,
            //          ITypeConverter<,>,
            //          IValueConverter<,>,
            //          IMappingAction<,>
            // Always
            // - Adds IConfigurationProvider as singleton using MapperConfigurationProvider
            // - Adds IMapper as Mapper using IConfigurationProvider
            services.AddAutoMapper(AutoMapperCoreConfiguration.ConfigAction);

            //MapperConfiguration.AssertConfigurationIsValid();

            // Authorization setup
            //services.AddSingleton<IAuthorizationHandler, ResourceAuthorizationHandler>();

            services.AddDomainServices(Configuration);

            // TODO: work out if we need to include supported media types
            //var json = config.Formatters.JsonFormatter;
            //json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            // Newtonsoft Json provides support for Json Patch
            services.AddControllers(options =>
                {
                    options.CacheProfiles.Add("Default5mins", new CacheProfile() { Duration = 300 });
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }


        // Configure is where you add middleware.        
        // You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // TODO: Stop trying to map tokens to .Net claim types?
            // JwtSecurityTokenHandler.DefaultMapInboundClaims = false;


            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging(); // Nicer HTTP request logging than standard MS stuff
            app.UseRouting();
            app.UseCors();
            
            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "api/{controller}/{id?}");
            });
        }
    }
}
