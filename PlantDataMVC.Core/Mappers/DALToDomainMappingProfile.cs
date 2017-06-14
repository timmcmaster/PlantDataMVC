using AutoMapper;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.DAL.Entities;
using System;

namespace PlantDataMVC.Core.Mappers
{
    public class DALToDomainMappingProfile : Profile
    {
        public DALToDomainMappingProfile()

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
                //.ForMember(bo => bo.LatinName, opt => opt.MapFrom<String>(e => String.Format("{0} {1}", e.GenusLatinName.Trim(), e.LatinName.Trim())))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(e => e.LatinName))
                .ForMember(bo => bo.Seeds, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()))
                .ForMember(bo => bo.Stock, opt => opt.MapFrom<PlantStock[]>(e => e.PlantStocks.ToArray()));

            CreateMap<SeedBatch, PlantSeed>()
                .ForMember(bo => bo.SeedTrays, opt => opt.MapFrom<SeedTray[]>(e => e.SeedTrays.ToArray()));

            CreateMap<Site, PlantSeedSite>()
                .ForMember(bo => bo.SeedBatches, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()));

            CreateMap<SeedTray, PlantSeedTray>()
                .ForMember(bo => bo.PlantStockTransactions, opt => opt.MapFrom<JournalEntry[]>(e => e.JournalEntries.ToArray()));

            CreateMap<PlantStock, PlantStockEntry>();

            CreateMap<JournalEntry, PlantStockTransaction>()
                .ForMember(bo => bo.PlantStockEntryId, opt => opt.MapFrom<int>(e => e.PlantStockId))
                .ForMember(bo => bo.TransactionType, opt => opt.MapFrom<JournalEntryType>(e => e.JournalEntryType));

            CreateMap<JournalEntryType, PlantStockTransactionType>();

            CreateMap<ProductPrice, PlantProductPrice>();

            CreateMap<ProductType, PlantProductType>();

            CreateMap<PriceListType, PlantPriceListType>();
        }
    }
}