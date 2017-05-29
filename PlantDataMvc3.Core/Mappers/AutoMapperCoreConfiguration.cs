using AutoMapper;
using System;
using System.Linq;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMvc3.Core.Mappers
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
            ConfigureDALToDomain();

            ConfigureDomainToDAL();
        }

        private static void ConfigureDALToDomain()
        {
            // Maps from Data Layer entities to Domain business objects
            // Note no map exists from Genus up to Plant (i.e. Mapper.CreateMap<Species, Plant>() )
            // as Species is required for defining Plant
            Mapper.CreateMap<Species, Plant>()
                //.ForMember(bo => bo.LatinName, opt => opt.MapFrom<String>(e => String.Format("{0} {1}", e.GenusLatinName.Trim(), e.LatinName.Trim())))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(e => e.LatinName))
                .ForMember(bo => bo.Seeds, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()))
                .ForMember(bo => bo.Stock, opt => opt.MapFrom<PlantStock[]>(e => e.PlantStocks.ToArray()));

            Mapper.CreateMap<SeedBatch, PlantSeed>()
                .ForMember(bo => bo.SeedTrays, opt => opt.MapFrom<SeedTray[]>(e => e.SeedTrays.ToArray()));

            Mapper.CreateMap<Site, PlantSeedSite>()
                .ForMember(bo => bo.SeedBatches, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()));

            Mapper.CreateMap<SeedTray, PlantSeedTray>()
                .ForMember(bo => bo.PlantStockTransactions, opt => opt.MapFrom<JournalEntry[]>(e => e.JournalEntries.ToArray()));

            Mapper.CreateMap<PlantStock, PlantStockEntry>();

            Mapper.CreateMap<JournalEntry, PlantStockTransaction>()
                .ForMember(bo => bo.PlantStockEntryId, opt => opt.MapFrom<int>(e => e.PlantStockId))
                .ForMember(bo => bo.TransactionType, opt => opt.MapFrom<JournalEntryType>(e => e.JournalEntryType));

            Mapper.CreateMap<JournalEntryType, PlantStockTransactionType>();

            Mapper.CreateMap<ProductPrice, PlantProductPrice>();

            Mapper.CreateMap<ProductType, PlantProductType>();

            Mapper.CreateMap<PriceListType, PlantPriceListType>();
        }

        private static void ConfigureDomainToDAL()
        {
            // Maps from Domain to DB models
            Mapper.CreateMap<Plant, Genus>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.GenusLatinName));
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? bo.LatinName : bo.LatinName.Substring(0, bo.LatinName.IndexOf(' '))));

            Mapper.CreateMap<Plant, Species>()
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? "" : bo.LatinName.Substring(bo.LatinName.IndexOf(' ') + 1)));

            Mapper.CreateMap<PlantSeed, SeedBatch>();

            Mapper.CreateMap<PlantSeedSite, Site>();

            Mapper.CreateMap<PlantSeedTray, SeedTray>();

            Mapper.CreateMap<PlantStockEntry, PlantStock>();

            Mapper.CreateMap<PlantStockTransaction, JournalEntry>()
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom<int>(bo => bo.PlantStockEntryId))
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom<int>(bo => bo.TransactionType.Id))
                .ForMember(e => e.JournalEntryType, opt => opt.Ignore());

            Mapper.CreateMap<PlantStockTransactionType, JournalEntryType>();

            Mapper.CreateMap<PlantProductPrice, ProductPrice>();

            Mapper.CreateMap<PlantProductType, ProductType>();

            Mapper.CreateMap<PlantPriceListType, PriceListType>();
        }
    }
}