using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using PlantData.Web.Blazor.Components;
using PlantData.Web.Blazor.DependencyInjection;
using PlantData.Web.Blazor.Helpers;
using PlantData.Web.Blazor.Mappers;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Constants;
using Serilog;
using Syncfusion.Blazor;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace PlantData.Web.Blazor
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            #region HttpClientFactory
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
            });

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
            #endregion HttpClientFactory

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

            // Add services to the container.
            //services.AddControllersWithViews();


            services.AddRazorComponents().AddInteractiveServerComponents();
            services.AddSyncfusionBlazor();

            // Main Domain stuff
            //services.AddDomainServices();
            //services.AddViewModelsAndInterfaces();

            services.AddSidebarMenuViewModelAndInterface();
        }

        // Configure is where you add middleware.        
        // You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH1fdnZVQ2deVkJwWUI=");

            // Stop trying to map tokens to .Net claim types
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/StatusCode/{0}"); // Redirect to error page on 404 (not found) 

            app.UseHttpsRedirection();

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".properties"] = "application/octet-stream";
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });

            app.UseSerilogRequestLogging(); // Nicer HTTP request logging than stdd Ms stuff

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAntiforgery();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorComponents<App>().AddInteractiveServerRenderMode();
                //endpoints.MapDefaultControllerRoute().RequireAuthorization();
                //endpoints.MapControllers();
                //endpoints.MapFallbackToPage()
            });
        }
    }
}
