using AutoMapper;

namespace PlantDataMVC.Domain.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile<DALToDomainMappingProfile>();
                //cfg.AddProfile<DomainToDALMappingProfile>();
                cfg.AddProfile<EFDALToDomainMappingProfile>();
                cfg.AddProfile<EFDomainToDALMappingProfile>();
            });
        }
    }

}