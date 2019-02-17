using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core.Services.InMemory;

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
                    Password = "ilikebikes",
                    Subject = "1",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Timothy"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "McMaster"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebReadUser"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebWriteUser"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebAdminUser"),
                    }
                },

                new InMemoryUser
                {
                    Username = "Kernip",
                    Password = "lovetorun",
                    Subject = "2",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Kerryn"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "Plummer"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebReadUser"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebWriteUser")
                    }
                },

                new InMemoryUser
                {
                    Username = "Longest",
                    Password = "nicholas",
                    Subject = "3",

                    Claims = new[]
                    {
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Joanne"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "Vayena"),
                        new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "WebReadUser")
                    }
                }
            };
        }
    }
}