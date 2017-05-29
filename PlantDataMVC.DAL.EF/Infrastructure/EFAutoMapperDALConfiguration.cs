using AutoMapper;

namespace PlantDataMVC.DAL.EF.Infrastructure
{
    /// <summary>
    /// This class sets up the AutoMapper mappings between the EF.Entities and the basic Entities passed out of the DAL.
    /// </summary>
    public static class AutoMapperDALConfigurationEF
    {
        /// <summary>
        /// Configure the mappings.
        /// </summary>
        public static void Configure()
        {
            ConfigureLocalToDAL();

            ConfigureDALToLocal();
        }

        private static void ConfigureLocalToDAL()
        {
            // Maps from EF ORM entities to Interface entities
            Mapper.CreateMap<EF.Entities.Genus, DAL.Entities.Genus>();
            Mapper.CreateMap<EF.Entities.JournalEntry, DAL.Entities.JournalEntry>();
            Mapper.CreateMap<EF.Entities.JournalEntryType, DAL.Entities.JournalEntryType>();
            Mapper.CreateMap<EF.Entities.PlantStock, DAL.Entities.PlantStock>();
            Mapper.CreateMap<EF.Entities.PriceListType, DAL.Entities.PriceListType>();
            Mapper.CreateMap<EF.Entities.ProductPrice, DAL.Entities.ProductPrice>();
            Mapper.CreateMap<EF.Entities.ProductType, DAL.Entities.ProductType>();
            Mapper.CreateMap<EF.Entities.SeedBatch, DAL.Entities.SeedBatch>();
            Mapper.CreateMap<EF.Entities.SeedTray, DAL.Entities.SeedTray>();
            Mapper.CreateMap<EF.Entities.Species, DAL.Entities.Species>()
                .ForMember(e => e.GenusLatinName, opt => opt.MapFrom<string>(orm => orm.Genus.LatinName));
            Mapper.CreateMap<EF.Entities.Site, DAL.Entities.Site>();
        }

        private static void ConfigureDALToLocal()
        {
            // Maps from Interface DAL.Entities to EF ORM DAL.Entities
            Mapper.CreateMap<DAL.Entities.Genus, EF.Entities.Genus>();
            Mapper.CreateMap<DAL.Entities.JournalEntry, EF.Entities.JournalEntry>();
            Mapper.CreateMap<DAL.Entities.JournalEntryType, EF.Entities.JournalEntryType>();
            Mapper.CreateMap<DAL.Entities.PlantStock, EF.Entities.PlantStock>();
            Mapper.CreateMap<DAL.Entities.PriceListType, EF.Entities.PriceListType>();
            Mapper.CreateMap<DAL.Entities.ProductPrice, EF.Entities.ProductPrice>();
            Mapper.CreateMap<DAL.Entities.ProductType, EF.Entities.ProductType>();
            Mapper.CreateMap<DAL.Entities.SeedBatch, EF.Entities.SeedBatch>();
            Mapper.CreateMap<DAL.Entities.SeedTray, EF.Entities.SeedTray>();
            Mapper.CreateMap<DAL.Entities.Species, EF.Entities.Species>();
            Mapper.CreateMap<DAL.Entities.Site, EF.Entities.Site>();
        }
    }
}