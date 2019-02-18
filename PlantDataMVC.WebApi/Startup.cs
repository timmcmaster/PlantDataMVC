using System;
using System.Threading.Tasks;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using PlantDataMVC.Constants;

[assembly: OwinStartup(typeof(PlantDataMVC.WebApi.Startup))]

namespace PlantDataMVC.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = PlantDataMvcConstants.IdSrv,
                RequiredScopes = new[] { "plantdataapi" }
            });

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
