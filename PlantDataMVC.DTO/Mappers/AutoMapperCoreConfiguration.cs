using System;
using AutoMapper;

namespace PlantDataMVC.DTO.Mappers
{
    public class AutoMapperCoreConfiguration
    {
        public MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(ConfigAction);
        }

        public static Action<IMapperConfigurationExpression> ConfigAction
            = cfg =>
            {
                cfg.AddProfile<EfDalToDtoMappingProfile>();
                cfg.AddProfile<EfDtoToDalMappingProfile>();
            };


        /// <summary>
        ///     NB: This will overwrite any previous Mapper definitions
        ///     This method should only be used for testing where we don't need higher layer maps
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(ConfigAction);
        }
    }
}