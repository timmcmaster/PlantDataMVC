using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using PlantDataMVC.Constants;
using PlantDataMVC.IdSrv;
using PlantDataMVC.IdSrv.Config;

[assembly: OwinStartup(typeof(Startup))]

namespace PlantDataMVC.IdSrv
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    IssuerUri = PlantDataMvcConstants.IdSrvIssuerUri,

                    Factory = new IdentityServerServiceFactory()
                              .UseInMemoryClients(Clients.Get())
                              .UseInMemoryUsers(Users.Get())
                              .UseInMemoryScopes(Scopes.Get()),

                    SigningCertificate = Certificate.Get() 
                });
            });
        }
    }
}