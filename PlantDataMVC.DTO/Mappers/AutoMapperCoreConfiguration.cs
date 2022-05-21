using System;
using AutoMapper;

namespace PlantDataMVC.DTO.Mappers
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
                cfg.AddProfile<EfDalToDtoMappingProfile>();
                cfg.AddProfile<EfDtoToDalMappingProfile>();
            };
    }
}