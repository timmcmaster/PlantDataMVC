﻿using System.Collections.Generic;
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
                new Client
                {
                    Enabled = true,
                    ClientName = "PlantData MVC Client (Hybrid Flow)",
                    ClientId = "mvc",
                    Flow = Flows.Hybrid,
                    RequireConsent = true,
                    RedirectUris = new List<string>
                    {
                        PlantDataMvcConstants.PlantDataApi
                    }
                }
            };
        }
    }
}