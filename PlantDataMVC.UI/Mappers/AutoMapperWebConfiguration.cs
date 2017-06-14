using AutoMapper;
using System;
using System.Collections.Generic;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.UI.Models;
using PlantDataMVC.UI.ServiceLayerAccess;

namespace PlantDataMVC.UI.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UIToDomainMappingProfile>();
                cfg.AddProfile<DomainToUIMappingProfile>();
            });
        }
    }
}