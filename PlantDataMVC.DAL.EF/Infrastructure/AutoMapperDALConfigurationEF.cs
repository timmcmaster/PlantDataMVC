using AutoMapper;

namespace PlantDataMVC.DAL.EF.Infrastructure
{
    /// <summary>
    /// This class sets up the AutoMapper mappings between the EF.Entities and the basic Entities passed out of the DAL.
    /// </summary>
    public static class AutoMapperDALConfigurationEF
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DALToLocalMappingProfile>();
                cfg.AddProfile<LocalToDALMappingProfile>();
            });
        }
    }

}