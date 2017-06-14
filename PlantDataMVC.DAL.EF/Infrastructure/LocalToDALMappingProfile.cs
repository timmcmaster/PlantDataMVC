using AutoMapper;

namespace PlantDataMVC.DAL.EF.Infrastructure
{
    public class LocalToDALMappingProfile : Profile
    {
        public LocalToDALMappingProfile()
        {
            ConfigureLocalToDAL();
        }

        private void ConfigureLocalToDAL()
        {
            // Maps from EF ORM entities to Interface entities
            CreateMap<EF.Entities.Genus, DAL.Entities.Genus>();
            CreateMap<EF.Entities.JournalEntry, DAL.Entities.JournalEntry>();
            CreateMap<EF.Entities.JournalEntryType, DAL.Entities.JournalEntryType>();
            CreateMap<EF.Entities.PlantStock, DAL.Entities.PlantStock>();
            CreateMap<EF.Entities.PriceListType, DAL.Entities.PriceListType>();
            CreateMap<EF.Entities.ProductPrice, DAL.Entities.ProductPrice>();
            CreateMap<EF.Entities.ProductType, DAL.Entities.ProductType>();
            CreateMap<EF.Entities.SeedBatch, DAL.Entities.SeedBatch>();
            CreateMap<EF.Entities.SeedTray, DAL.Entities.SeedTray>();
            CreateMap<EF.Entities.Species, DAL.Entities.Species>()
                .ForMember(e => e.GenusLatinName, opt => opt.MapFrom<string>(orm => orm.Genus.LatinName));
            CreateMap<EF.Entities.Site, DAL.Entities.Site>();
        }

    }
}
