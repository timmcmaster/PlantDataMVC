using AutoMapper;

namespace PlantDataMVC.DAL.EF.Infrastructure
{
    public class DALToLocalMappingProfile : Profile
    {
        public DALToLocalMappingProfile()
        {
            ConfigureDALToLocal();
        }

        private void ConfigureDALToLocal()
        {
            // Maps from Interface DAL.Entities to EF ORM DAL.Entities
            CreateMap<DAL.Entities.Genus, EF.Entities.Genus>();
            CreateMap<DAL.Entities.JournalEntry, EF.Entities.JournalEntry>();
            CreateMap<DAL.Entities.JournalEntryType, EF.Entities.JournalEntryType>();
            CreateMap<DAL.Entities.PlantStock, EF.Entities.PlantStock>();
            CreateMap<DAL.Entities.PriceListType, EF.Entities.PriceListType>();
            CreateMap<DAL.Entities.ProductPrice, EF.Entities.ProductPrice>();
            CreateMap<DAL.Entities.ProductType, EF.Entities.ProductType>();
            CreateMap<DAL.Entities.SeedBatch, EF.Entities.SeedBatch>();
            CreateMap<DAL.Entities.SeedTray, EF.Entities.SeedTray>();
            CreateMap<DAL.Entities.Species, EF.Entities.Species>();
            CreateMap<DAL.Entities.Site, EF.Entities.Site>();
        }
    }
}
