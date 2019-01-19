using AutoMapper;
using System;

namespace PlantDataMVC.DTO.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction 
            = new Action<IMapperConfigurationExpression>(cfg =>
        {
            cfg.AddProfile<EfDalToDtoMappingProfile>();
            cfg.AddProfile<EfDtoToDalMappingProfile>();
        });


        /// <summary>
        /// NB: This will overwrite any previous Mapper definitions
        /// This method should only be used for testing where we don't need higher layer maps 
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(ConfigAction);
        }
    }

   
}