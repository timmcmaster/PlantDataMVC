using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using PlantDataMVC.Constants;
using PlantDataMVC.UI.Helpers;

[assembly: OwinStartup(typeof(PlantDataMVC.UI.Startup))]

namespace PlantDataMVC.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc",
                Authority = PlantDataMvcConstants.IdSrv,
                RedirectUri = PlantDataMvcConstants.PlantDataClient,
                SignInAsAuthenticationType = "Cookies",

                ResponseType = "code id_token",
                Scope = "openid profile",

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    MessageReceived = async n =>
                    {
                        EndpointAndTokenHelper.DecodeAndWrite(n.ProtocolMessage.IdToken);
                    }
                }
            });
        }
    }
}
