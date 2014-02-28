using AutoMapper;
using System;
using System.Collections.Generic;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.UI.ServiceLayerAccess;

namespace PlantDataMvc3.UI.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new BasicProfile()));
        }

    }
}