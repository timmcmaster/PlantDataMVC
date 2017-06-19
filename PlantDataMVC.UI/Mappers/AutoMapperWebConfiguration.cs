using AutoMapper;

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