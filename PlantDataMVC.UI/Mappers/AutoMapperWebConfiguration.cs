using AutoMapper;
using System;

namespace PlantDataMVC.UI.Mappers
{
    public static class AutoMapperWebConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction
            = new Action<IMapperConfigurationExpression>(cfg =>
            {
                cfg.AddProfile<UIToDTOMappingProfile>();
                cfg.AddProfile<DTOToUIMappingProfile>();
            });


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