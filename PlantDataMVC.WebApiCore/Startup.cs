using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using PlantDataMVC.Constants;
using PlantDataMVC.WebApiCore.Helpers;
using PlantDataMVC.WebApiCore.Mappers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using CacheCow.Server.Core.Mvc;
//using Microsoft.AspNetCore.Mvc.Versioning;
using NLog;
using NLog.Web;

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
            services.AddMvcCore(options =>
            {
                // IS3 does not include the api name/audience - hence the extra scope check
                options.Filters.Add(new AuthorizeFilter(ScopePolicy.Create("plantdataapi")));

            });

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

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = PlantDataMvcConstants.IdSrv;
                    options.RequireHttpsMetadata = false;
                    //options.ApiName = "";
                    //options.ApiSecret = "";
                    //RequiredScopes = new[] { "plantdataapi" }

                    // this is only needed because IS3 does not include the API name in the JWT audience list
                    // so we disable UseIdentityServerAuthentication JWT audience check and rely upon
                    // scope validation to ensure we're only accepting tokens for the right API
                    options.LegacyAudienceValidation = true;

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
            services.AddApiVersioning(options =>
            {

            });

            services.AddHttpCachingMvc();

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
