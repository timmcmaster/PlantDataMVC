using System.Collections.Generic;
using IdentityServer3.Core.Models;
using PlantDataMVC.Constants;

namespace PlantDataMVC.IdSrv.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                // MVC App
                new Client
                {
                    Enabled = true,
                    ClientName = "PlantData MVC Client (Hybrid Flow)",
                    ClientId = "mvc",
                    Flow = Flows.Hybrid,
                    RequireConsent = true,
                    RedirectUris = new List<string>
                    {
                        PlantDataMvcConstants.PlantDataClient
                    },
                    AllowAccessToAllScopes = true,

                    // Provide secret to allow for refresh tokens
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                },
                // Postman test client
                new Client
                {
                    Enabled = true,
                    ClientName = "Postman Test Client (Hybrid Flow)",
                    ClientId = "postman-api",
                    Flow = Flows.AuthorizationCode,
                    AccessTokenLifetime = 43200, // 12 hours
                    RequireConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://www.getpostman.com/oauth2/callback"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://www.getpostman.com"
                    },
                    AllowAccessToAllScopes = true,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                }

            };
        }
    }
}