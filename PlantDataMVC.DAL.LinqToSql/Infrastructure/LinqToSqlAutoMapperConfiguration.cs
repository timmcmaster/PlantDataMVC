using AutoMapper;

namespace PlantDataMVC.DAL.LinqToSql.Infrastructure
{
    public static class AutoMapperDALConfigurationLinqToSql
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
            // Maps from LinqToSQL ORM entities to Interface entities
            Mapper.CreateMap<LinqToSql.Entities.Genus, DAL.Entities.Genus>();
            Mapper.CreateMap<LinqToSql.Entities.JournalEntry, DAL.Entities.JournalEntry>();
            Mapper.CreateMap<LinqToSql.Entities.JournalEntryType, DAL.Entities.JournalEntryType>();
            Mapper.CreateMap<LinqToSql.Entities.PlantStock, DAL.Entities.PlantStock>();
            Mapper.CreateMap<LinqToSql.Entities.PriceListType, DAL.Entities.PriceListType>();
            Mapper.CreateMap<LinqToSql.Entities.ProductPrice, DAL.Entities.ProductPrice>();
            Mapper.CreateMap<LinqToSql.Entities.ProductType, DAL.Entities.ProductType>();
            Mapper.CreateMap<LinqToSql.Entities.SeedBatch, DAL.Entities.SeedBatch>();
            Mapper.CreateMap<LinqToSql.Entities.SeedTray, DAL.Entities.SeedTray>();
            Mapper.CreateMap<LinqToSql.Entities.Species, DAL.Entities.Species>()
                .ForMember(e => e.GenusLatinName, opt => opt.MapFrom<string>(orm => orm.Genus.LatinName));
            Mapper.CreateMap<LinqToSql.Entities.Site, DAL.Entities.Site>();
        }

        private static void ConfigureDALToLocal()
        {
            // Maps from Interface entities to LinqToSQL ORM entities
            Mapper.CreateMap<DAL.Entities.Genus, LinqToSql.Entities.Genus>();
            Mapper.CreateMap<DAL.Entities.JournalEntry, LinqToSql.Entities.JournalEntry>();
            Mapper.CreateMap<DAL.Entities.JournalEntryType, LinqToSql.Entities.JournalEntryType>();
            Mapper.CreateMap<DAL.Entities.PlantStock, LinqToSql.Entities.PlantStock>();
            Mapper.CreateMap<DAL.Entities.PriceListType, LinqToSql.Entities.PriceListType>();
            Mapper.CreateMap<DAL.Entities.ProductPrice, LinqToSql.Entities.ProductPrice>();
            Mapper.CreateMap<DAL.Entities.ProductType, LinqToSql.Entities.ProductType>();
            Mapper.CreateMap<DAL.Entities.SeedBatch, LinqToSql.Entities.SeedBatch>();
            Mapper.CreateMap<DAL.Entities.SeedTray, LinqToSql.Entities.SeedTray>();
            Mapper.CreateMap<DAL.Entities.Species, LinqToSql.Entities.Species>();
            Mapper.CreateMap<DAL.Entities.Site, LinqToSql.Entities.Site>();
        }
    }
}