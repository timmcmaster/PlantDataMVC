
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
//using Owin;

namespace PlantDataMVC.IdSrv
{
    using IdentityServer3.Core.Configuration;
    using Microsoft.AspNetCore.Hosting;
    using PlantDataMVC.Constants;
    using PlantDataMVC.IdSrv.Config;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment host)
        {
            app.Map("/identity", idsrvApp =>
            {
                var factory = new IdentityServerServiceFactory()
                          .UseInMemoryClients(Clients.Get())
                          .UseInMemoryUsers(Users.Get())
                          .UseInMemoryScopes(Scopes.Get());

                var options = new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    IssuerUri = PlantDataMvcConstants.IdSrvIssuerUri,
                    SigningCertificate = Certificate.Get(),
                    Factory = factory
                };

                idsrvApp.UseIdentityServer(options);
            });
        }
    }
}
