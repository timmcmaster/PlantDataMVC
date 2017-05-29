using AutoMapper;
using System;
using System.Collections.Generic;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
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