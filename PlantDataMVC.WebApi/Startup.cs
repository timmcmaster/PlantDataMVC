using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using PlantDataMVC.Constants;
using PlantDataMVC.WebApi.Helpers;

[assembly: OwinStartup(typeof(PlantDataMVC.WebApi.Startup))]

namespace PlantDataMVC.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Stop trying to map tokens to .Net claim types
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = PlantDataMvcConstants.IdSrv,
                RequiredScopes = new[] { "plantdataapi" }
            });

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
