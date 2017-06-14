using AutoMapper;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using System;

namespace PlantDataMVC.Core.Mappers
{
    public class DomainToDALMappingProfile: Profile
    {
        public DomainToDALMappingProfile()
        {
            ConfigureDomainToDAL();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the DAL objects
        /// </summary>
        private void ConfigureDomainToDAL()
        {
            // Maps from Domain to DB models
            CreateMap<Plant, Genus>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.GenusLatinName));
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? bo.LatinName : bo.LatinName.Substring(0, bo.LatinName.IndexOf(' '))));

            CreateMap<Plant, Species>()
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? "" : bo.LatinName.Substring(bo.LatinName.IndexOf(' ') + 1)));

            CreateMap<PlantSeed, SeedBatch>();

            CreateMap<PlantSeedSite, Site>();

            CreateMap<PlantSeedTray, SeedTray>();

            CreateMap<PlantStockEntry, PlantStock>();

            CreateMap<PlantStockTransaction, JournalEntry>()
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom<int>(bo => bo.PlantStockEntryId))
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom<int>(bo => bo.TransactionType.Id))
                .ForMember(e => e.JournalEntryType, opt => opt.Ignore());

            CreateMap<PlantStockTransactionType, JournalEntryType>();

            CreateMap<PlantProductPrice, ProductPrice>();

            CreateMap<PlantProductType, ProductType>();

            CreateMap<PlantPriceListType, PriceListType>();
        }
    }
}