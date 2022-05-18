using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using PlantDataMVC.Constants;
using System.Collections.Generic;

namespace PlantDataMVC.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        /*
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                // generic scope for api access (not broken down at all)
                new ApiResource(name: "plantdataapi", displayName: "PlantData API Scope"),
                new ApiResource(name: "plantdataapi", displayName: "Postman Test Resource")
            };
        */

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                // generic scope for api access (not broken down at all)
                new ApiScope(name: "plantdataapi", displayName: "PlantData API Scope")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // MVC App - hybrid flow
                //new Client
                //{
                //    Enabled = true,
                //    ClientName = "PlantData MVC Client (Hybrid Flow)",
                //    ClientId = "mvc",
                //    // Provide secret to allow for refresh tokens
                //    ClientSecrets = new List<Secret>
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedGrantTypes = GrantTypes.Hybrid,
                //    RequireConsent = true,
                //    RedirectUris = new List<string>
                //    {
                //        PlantDataMvcConstants.PlantDataClient
                //    },
                //    AllowedScopes = new List<string> () {"plantdataapi"}
                //},
                // Interaactive client MVC App
                new Client
                {
                    Enabled = true,
                    ClientName = "PlantData MVC Client (Code Flow)",
                    ClientId = "mvc-web",
                    // Provide secret to allow for refresh tokens
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = true,
                    RedirectUris = { PlantDataMvcConstants.PlantDataClient + "/signin-oidc" }, // sign-in page
                    PostLogoutRedirectUris = { PlantDataMvcConstants.PlantDataClient + "/signout-callback-oidc" }, // sign-out callback page
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                // MVC App - client credentials flow
                new Client
                {
                    Enabled = true,
                    ClientName = "PlantData MVC Client",
                    ClientId = "mvc-client",
                    // Provide secret to allow for refresh tokens
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string> () {"plantdataapi"}
                }
                /*,
                // Postman test client
                new Client
                {
                    Enabled = true,
                    ClientName = "Postman Test Client (Hybrid Flow)",
                    ClientId = "postman-api",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes= GrantTypes.Code,
                    AccessTokenLifetime = 43200, // 12 hours
                    RequireConsent = false,
                    RedirectUris = { "https://www.getpostman.com/oauth2/callback" },
                    PostLogoutRedirectUris = { "http://www.getpostman.com" },
                    AllowedCorsOrigins = { "http://www.getpostman.com" },
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "postman_api",
                        "plantdataapi"
                    }
                }
                */
                /*
                ,
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "scope1" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                }
                */
            };
    };
}