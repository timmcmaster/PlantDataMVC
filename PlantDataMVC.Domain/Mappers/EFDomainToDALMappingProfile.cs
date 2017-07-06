using AutoMapper;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.Domain.Mappers
{
    // HACK: This probably shouldn't be here and should be done by IoC - to fix
    public class EFDomainToDALMappingProfile: Profile
    {
        public EFDomainToDALMappingProfile()
        {
            ConfigureDomainToDAL();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the DAL objects
        /// </summary>
        private void ConfigureDomainToDAL()
        {
            // TODO: Suggestions from web that it is not good practice to map downwards - read why, then fix
            // Maps from Domain to DB models
            CreateMap<Plant, Genus>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
                .ForMember(e => e.Species, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? bo.LatinName : bo.LatinName.Substring(0, bo.LatinName.IndexOf(' '))));

            CreateMap<Plant, Species>()
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName))
                .ForMember(e => e.GenusId, opt => opt.MapFrom(bo => bo.Id))
                .ForMember(e => e.Genus, opt => opt.Ignore())
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.SeedBatches, opt => opt.Ignore())
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? "" : bo.LatinName.Substring(bo.LatinName.IndexOf(' ') + 1)));

            // TODO: Need SeedBatch to link to site definition
            //       and map back site ID, not just location string
            CreateMap<PlantSeed, SeedBatch>()
                .ForMember(e => e.SiteId, opt => opt.Ignore())
                .ForMember(e => e.Site, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantSeedSite, Site>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantSeedTray, SeedTray>()
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.SeedBatch, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantStockEntry, PlantStock>()
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantStockTransaction, JournalEntry>()
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom<int>(bo => bo.PlantStockEntryId))
                .ForMember(e => e.PlantStock, opt => opt.Ignore())
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom<int>(bo => bo.TransactionType.Id))
                .ForMember(e => e.JournalEntryType, opt => opt.Ignore())
                .ForMember(e => e.SeedTray, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.Source, opt => opt.MapFrom(bo => bo.TransactionSource));

            CreateMap<PlantStockTransactionType, JournalEntryType>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.JournalEntries, opt => opt.Ignore());

            CreateMap<PlantProductPrice, ProductPrice>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantProductType, ProductType>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.ProductPrices, opt => opt.Ignore());

            CreateMap<PlantPriceListType, PriceListType>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.ProductPrices, opt => opt.Ignore());
        }
    }
}