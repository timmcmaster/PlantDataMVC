using AutoMapper;
using System;

namespace PlantDataMVC.UI.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction
            = cfg =>
            {
                cfg.AddProfile<UiToDtoMappingProfile>();
                cfg.AddProfile<DtoToUiMappingProfile>();
            };


        /// <summary>
        /// NB: This will overwrite any previous Mapper definitions
        /// This method should only be used for testing where we don't need other layer maps 
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(ConfigAction);
        }
    }
}