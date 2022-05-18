using CacheCow.Server.Core.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using PlantDataMVC.Constants;
using PlantDataMVC.WebApiCore.DependencyInjection;
using PlantDataMVC.WebApiCore.Helpers;
using PlantDataMVC.WebApiCore.Mappers;
using Serilog;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Mvc.Versioning;

namespace PlantDataMVC.WebApiCore
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
            // TODO: clean this up - split services definitions for each middleware app?
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            });

            // 1. Identity Server setup 
            services.AddMvcCore();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.RequireReadUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebReadUser);
                });
                options.AddPolicy(AuthorizationPolicies.RequireWriteUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebWriteUser);
                });
                options.AddPolicy(AuthorizationPolicies.RequireAdminUserRole, policy =>
                {
                    policy.RequireRole(AuthorizationRole.WebAdminUser);
                });
            });

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

            // TODO: Investigate versioning using this package
            //services.AddApiVersioning(options =>
            //{

            //});

            // TODO: investigate Built-in caching vs CacheCow
            services.AddHttpCachingMvc();
            //services.AddResponseCaching(options =>
            //{

            //});


            // Authorization setup
            //services.AddSingleton<IAuthorizationHandler, ResourceAuthorizationHandler>();

            services.AddDomainServices();

            // TODO: work out if we need to include supported media types
            //var json = config.Formatters.JsonFormatter;
            //json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //json.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json-patch+json"));

            // Newtonsoft Jspon provides support for Json Patch
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }


        // Configure is where you add middleware.        
        // You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment host)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // TODO: clean this up - split middleware definitions?

            // Stop trying to map tokens to .Net claim types
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging(); // Nicer HTTP request logging than stdd Ms stuff
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{id?}");
            });

            AutoMapperBootstrapper.Initialize();
        }
    }
}
