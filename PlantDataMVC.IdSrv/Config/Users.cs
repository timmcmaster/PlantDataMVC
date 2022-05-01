using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core.Services.InMemory;
using PlantDataMVC.Constants;

namespace PlantDataMVC.IdSrv.Config
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser
                {
                    Username = "Timmo",
                    Password = "secret",
                    Subject = "1",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Timothy"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "McMaster"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebReadUser),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebWriteUser),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebAdminUser)
                    }
                },

                new InMemoryUser
                {
                    Username = "Kerryn",
                    Password = "secret",
                    Subject = "2",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Kerryn"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "Plummer"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebReadUser),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebWriteUser)
                    }
                },

                new InMemoryUser
                {
                    Username = "Jo",
                    Password = "secret",
                    Subject = "3",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Joanne"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "Vayena"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, AuthorizationRole.WebReadUser)
                    }
                }
            };
        }
    }
}