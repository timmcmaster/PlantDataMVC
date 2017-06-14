using AutoMapper;

namespace PlantDataMVC.Core.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DALToDomainMappingProfile>();
                cfg.AddProfile<DomainToDALMappingProfile>();
            });
        }
    }

}