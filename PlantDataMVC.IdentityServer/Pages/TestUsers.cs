// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer;
using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using System.Collections.Generic;
using PlantDataMVC.Constants;

namespace PlantDataMVC.IdentityServer
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "17 Delville St",
                    locality = "Annerley",
                    region = "QLD",
                    postal_code = 4011,
                    country = "Australia"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "Timmo",
                        Password = "secret",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Tim McMaster"),
                            new Claim(JwtClaimTypes.GivenName, "Tim"),
                            new Claim(JwtClaimTypes.FamilyName, "McMaster"),
                            new Claim(JwtClaimTypes.Email, "Tim.McMaster@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://timmo.com.au"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            // Role claims
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebReadUser),
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebWriteUser),
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebAdminUser)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "2",
                        Username = "Kerryn",
                        Password = "secret",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Kerryn Plummer"),
                            new Claim(JwtClaimTypes.GivenName, "Kerryn"),
                            new Claim(JwtClaimTypes.FamilyName, "Plummer"),
                            // Role claims
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebReadUser),
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebWriteUser)
                       },
                    },
                    new TestUser
                    {
                        SubjectId = "3",
                        Username = "Jo",
                        Password = "secret",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Joanne Vayena"),
                            new Claim(JwtClaimTypes.GivenName, "Joanne"),
                            new Claim(JwtClaimTypes.FamilyName, "Vayena"),
                            // Role claims
                            new Claim(JwtClaimTypes.Role, AuthorizationRole.WebReadUser)
                        }
                    }
                };
            }
        }
    }
}