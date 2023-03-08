using IdentityModel;
using IdentityModel.Client;
using IdentityModel.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlantDataMVC.Constants;
using PlantDataMVC.Web.DependencyInjection;
using PlantDataMVC.Web.Helpers;
using System;
using System.Net.Http.Headers;
using Serilog;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using PlantDataMVC.Web.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using PlantDataMVC.Common.Client;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Razor;
//using Microsoft.AspNetCore.Mvc.Versioning;

namespace PlantDataMVC.Web
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
            // Authentication 
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = PlantDataMvcConstants.IdSrvBase;

                options.ClientId = "mvc.interactive";
                options.ClientSecret = "secret";
                options.ResponseType = OpenIdConnectResponseType.Code;
                
                options.Scope.Clear();
                options.Scope.Add(OidcConstants.StandardScopes.OpenId);
                options.Scope.Add(OidcConstants.StandardScopes.Profile);
                options.Scope.Add("plantdataapi");
                options.Scope.Add(OidcConstants.StandardScopes.OfflineAccess);
                options.Scope.Add("roles");

                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClaimActions.MapUniqueJsonKey(JwtClaimTypes.Role, JwtClaimTypes.Role); // results in role claim(s) showing on home index page
                options.SaveTokens = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role
                };
            });

            // Authorization
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

            // HttpClientFactory
            // -->

            // TODO: This tokenrequest singleton shouldn't really be here
            // Add clientcredentialstokenrequest
            services.AddSingleton(new ClientCredentialsTokenRequest
            {
                // ProtocolRequest elements
                ClientId = "mvc.m2m",
                ClientSecret = "secret",
                //ClientCredentialStyle =  ClientCredentialStyle.AuthorizationHeader

                // ClientCredentialsRequest elements
                Scope = "plantdataapi"
                //Resource = new List<string>()
            }); ;

            services.AddTransient<BearerTokenMessageHandler>();

            services.AddHttpClient<IIdentityServerClient, IdentityServerClient>(client =>
            {
                client.BaseAddress = new Uri(PlantDataMvcConstants.IdSrvBase);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<IPlantDataApiClient, PlantDataApiClient>(client =>
            {
                client.BaseAddress = new Uri(PlantDataMvcConstants.PlantDataApi);

                // clear the accept headers and set those we require for ALL client requests
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).AddHttpMessageHandler<BearerTokenMessageHandler>();
            // <--

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
            // - Adds IMapper as Mapper using IConfiguratrionProvider
            services.AddAutoMapper(AutoMapperWebConfiguration.ConfigAction);

            // Main Domain stuff
            services.AddDomainServices();

            // MVC
            services.AddControllersWithViews()
                .AddJsonOptions(jsonOptions => jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null) // Don't convert property names to camelCase
                .AddRazorOptions(options =>
                {
                    // Allow for view components to be under ViewComponents/Components folder at root as well as Views/Shared/Components folder
                    options.ViewLocationFormats.Add("/ViewComponents/{0}" + RazorViewEngine.ViewExtension);  
                });        
        }


        // Configure is where you add middleware.        
        // You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhjVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSH9TdkJiUX5Wc3JWQg==;Mgo+DSMBPh8sVXJ0S0J+XE9HflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0RjWXhfeHVdRWdVVQ==;ORg4AjUWIQA/Gnt2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRiWX9ZcXxUTmNVVkA=;OTEwODg0QDMyMzAyZTM0MmUzMGlBdkh1Q25xS3VRWnlTWGNrNzlVUzhSWWdsamJ1amRIaUZUNGtHZ1FkZDg9;OTEwODg1QDMyMzAyZTM0MmUzMFdIZnBCeWVkcTIwcmNJT25DSzFrejlZem45blNraUphRXVjY08rMGNmWU09;NRAiBiAaIQQuGjN/V0Z+WE9EaFxKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUViWH9ed3VdR2hYVkdy;OTEwODg3QDMyMzAyZTM0MmUzMElON042c3EwNi85cFE3aFF6SU9EOXJWU0oxTEFzUFlacDlLalhpSE9LQXc9;OTEwODg4QDMyMzAyZTM0MmUzMGNSaTByUXNRMldSaDJUcjZseFVCSUI2bE1JdkNwT3EwZFJoWFFIVTVCakk9;Mgo+DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRiWX9ZcXxUTmVYUEA=;OTEwODkwQDMyMzAyZTM0MmUzMFFQNGNDeHpHMmx3OE1jZ2syVmhiZWxLeHRRVkptYzBYVTJ5Zm9RbXNHRmM9;OTEwODkxQDMyMzAyZTM0MmUzMG5iTUlsNWhVOWU5YS9LT3JXNGdMNzNkckV2azB4UlU3UHFrU3lyTzRkOTg9;OTEwODkyQDMyMzAyZTM0MmUzMElON042c3EwNi85cFE3aFF6SU9EOXJWU0oxTEFzUFlacDlLalhpSE9LQXc9");

            // Stop trying to map tokens to .Net claim types
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseSerilogRequestLogging(); // Nicer HTTP request logging than stdd Ms stuff
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
