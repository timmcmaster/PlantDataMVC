using System;
using AutoMapper;

namespace PlantDataMVC.Api.Models.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(ConfigAction);
        }

        public static Action<IMapperConfigurationExpression> ConfigAction
            = cfg =>
            {
                cfg.AddProfile<EntityModelToDataModelMappingProfile>();
                cfg.AddProfile<DataModelToEntityModelMappingProfile>();
            };
    }
}