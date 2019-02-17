using System.Collections.Generic;
using IdentityServer3.Core.Models;
using PlantDataMVC.Constants;

namespace PlantDataMVC.IdSrv.Config
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>()
            {
                // identity scopes
                StandardScopes.OpenId,
                StandardScopes.Profile,
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    DisplayName = "Roles",
                    Description = "The roles you belong to.",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                }
            };

            //var scopes = StandardScopes.All;

            return scopes;
        }
    }
}