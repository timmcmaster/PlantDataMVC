using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
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
                    Password = "ilikebikes",
                    Subject = "1",

                    Claims = new[]
                    {
                        new Claim(ClaimTypes.GivenName, "Timothy"),
                        new Claim(ClaimTypes.Surname, "McMaster"),
                    }
                },
                new InMemoryUser
                {
                    Username = "Kernip",
                    Password = "lovetorun",
                    Subject = "2",

                    Claims = new[]
                    {
                        new Claim(ClaimTypes.GivenName, "Kerryn"),
                        new Claim(ClaimTypes.Surname, "Plummer"),
                    }
                },
                new InMemoryUser
                {
                    Username = "Longest",
                    Password = "nicholas",
                    Subject = "3",

                    Claims = new[]
                    {
                        new Claim(ClaimTypes.GivenName, "Joanne"),
                        new Claim(ClaimTypes.Surname, "Vayena"),
                    }
                }
            };
        }
    }
}