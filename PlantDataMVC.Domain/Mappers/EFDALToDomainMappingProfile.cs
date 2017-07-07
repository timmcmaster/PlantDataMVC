using AutoMapper;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.Domain.Mappers
{
    // HACK: This probably shouldn't be here and should be done by IoC - to fix
    public class EFDALToDomainMappingProfile : Profile
    {
        public EFDALToDomainMappingProfile()
        {
            ConfigureDALToDomain();
        }

        /// <summary>
        /// Configure the mappings from the DAL objects to the App/Business Layer objects
        /// </summary>
        private void ConfigureDALToDomain()
        {
            // Maps from Data Layer entities to Domain business objects
            // Note no map exists from Genus up to Plant (i.e. Mapper.CreateMap<Species, Plant>() )
            // as Species is required for defining Plant
            CreateMap<Species, Plant>()
                .ForMember(bo => bo.Seeds, opt => opt.Ignore())
                .ForMember(bo => bo.Stock, opt => opt.Ignore());
            //.ForMember(bo => bo.Seeds, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()))
            //.ForMember(bo => bo.Stock, opt => opt.MapFrom<PlantStock[]>(e => e.PlantStocks.ToArray()));

            CreateMap<SeedBatch, PlantSeed>();
            //.ForMember(bo => bo.SeedTrays, opt => opt.MapFrom<SeedTray[]>(e => e.SeedTrays.ToArray()));

            CreateMap<Site, PlantSeedSite>();
            //.ForMember(bo => bo.SeedBatches, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()));

            CreateMap<SeedTray, PlantSeedTray>()
                .ForMember(bo => bo.PlantStockTransactions, opt => opt.Ignore());
                //.ForMember(bo => bo.PlantStockTransactions, opt => opt.MapFrom<JournalEntry[]>(e => e.JournalEntries.ToArray()));

            CreateMap<PlantStock, PlantStockEntry>()
                .ForMember(bo => bo.Transactions, opt => opt.Ignore());

            CreateMap<JournalEntry, PlantStockTransaction>()
                .ForMember(bo => bo.PlantStockEntryId, opt => opt.MapFrom(e => e.PlantStockId))
                .ForMember(bo => bo.TransactionType, opt => opt.MapFrom(e => e.JournalEntryType))
                .ForMember(bo => bo.TransactionSource, opt => opt.MapFrom(e => e.Source));

            CreateMap<JournalEntryType, PlantStockTransactionType>();

            CreateMap<ProductPrice, PlantProductPrice>();

            CreateMap<ProductType, PlantProductType>();

            CreateMap<PriceListType, PlantPriceListType>();
        }
    }
}