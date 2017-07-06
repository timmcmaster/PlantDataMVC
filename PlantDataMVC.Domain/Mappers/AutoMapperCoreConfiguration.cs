using AutoMapper;
using AutoMapper.Configuration;
using System;

namespace PlantDataMVC.Domain.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static Action<IMapperConfigurationExpression> ConfigAction 
            = new Action<IMapperConfigurationExpression>(cfg =>
        {
            //cfg.AddProfile<DALToDomainMappingProfile>();
            //cfg.AddProfile<DomainToDALMappingProfile>();
            cfg.AddProfile<EFDALToDomainMappingProfile>();
            cfg.AddProfile<EFDomainToDALMappingProfile>();
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