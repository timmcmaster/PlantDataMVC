using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Newtonsoft.Json.Linq;
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

            // Stop trying to map tokens to .Net claim types
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "unique_user_key";

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "mvc",
                Authority = PlantDataMvcConstants.IdSrv,
                RedirectUri = PlantDataMvcConstants.PlantDataClient,
                PostLogoutRedirectUri = PlantDataMvcConstants.PlantDataClient,
                SignInAsAuthenticationType = "Cookies",

                ResponseType = "code id_token token",
                Scope = "openid profile roles",

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    MessageReceived = async n =>
                    {
                        //EndpointAndTokenHelper.DecodeAndWrite(n.ProtocolMessage.IdToken);
                        //EndpointAndTokenHelper.DecodeAndWrite(n.ProtocolMessage.AccessToken);

                        //var userInfo = await EndpointAndTokenHelper.CallUserInfoEndpoint(n.ProtocolMessage.AccessToken);
                    },
                    SecurityTokenValidated = async n =>
                    {
                        // Claims mapping and simplification
                        // Get user info claims
                        var userInfo = await EndpointAndTokenHelper.CallUserInfoEndpoint(n.ProtocolMessage.AccessToken);

                        var givenNameClaim = new Claim(IdentityModel.JwtClaimTypes.GivenName, userInfo.Value<string>("given_name"));
                        var familyNameClaim = new Claim(IdentityModel.JwtClaimTypes.FamilyName, userInfo.Value<string>("family_name"));

                        var roles = userInfo.Value<JArray>("role").ToList();

                        var newIdentity = new ClaimsIdentity(
                            n.AuthenticationTicket.Identity.AuthenticationType,
                            IdentityModel.JwtClaimTypes.GivenName,
                            IdentityModel.JwtClaimTypes.Role);

                        newIdentity.AddClaim(givenNameClaim);
                        newIdentity.AddClaim(familyNameClaim);

                        foreach (var role in roles)
                        {
                            newIdentity.AddClaim(new Claim(IdentityModel.JwtClaimTypes.Role, role.ToString()));
                        }

                        // get required identifier token claims (used for antiforgery tokens)
                        var issuerClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Issuer);
                        var subjectClaim = n.AuthenticationTicket.Identity.FindFirst(IdentityModel.JwtClaimTypes.Subject);
                        
                        newIdentity.AddClaim(new Claim("unique_user_key", issuerClaim.Value + "_" + subjectClaim.Value));
 
                        n.AuthenticationTicket = new AuthenticationTicket(newIdentity, n.AuthenticationTicket.Properties);
                    }
                }
            });
        }
    }
}
