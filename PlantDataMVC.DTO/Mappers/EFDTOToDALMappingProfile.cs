using AutoMapper;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.DTO.Mappers
{
    public class EFDTOToDALMappingProfile: Profile
    {
        public EFDTOToDALMappingProfile()
        {
            ConfigureDTOToDAL();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the DAL objects
        /// </summary>
        private void ConfigureDTOToDAL()
        {
            // TODO: Suggestions from web that it is not good practice to map downwards - read why, then fix
            // Maps from Domain to DB models
            CreateMap<GenusDTO, Genus>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                    // explicit and unnecessary
                .ForMember(e => e.LatinName, opt => opt.MapFrom(dto => dto.LatinName))      // explicit and unnecessary
                .ForMember(e => e.Species, opt => opt.Ignore());
            /*
            CreateMap<Plant, Genus>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => bo.GenericName))
                .ForMember(e => e.Species, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? bo.LatinName : bo.LatinName.Substring(0, bo.LatinName.IndexOf(' '))));

            CreateMap<Plant, Species>()
                .ForMember(e => e.GenusId, opt => opt.Ignore()) // TODO: Will need GenusId on species
                .ForMember(e => e.Genus, opt => opt.Ignore())
                .ForMember(e => e.GenericName, opt => opt.Ignore())
                .ForMember(e => e.Binomial, opt => opt.Ignore())
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.SeedBatches, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());
            //.ForMember(e => e.LatinName, opt => opt.MapFrom<String>(bo => (bo.LatinName.IndexOf(' ') == -1) ? "" : bo.LatinName.Substring(bo.LatinName.IndexOf(' ') + 1)));

            CreateMap<PlantSeed, SeedBatch>()
                //.ForMember(e => e.SiteId, opt => opt.Ignore())
                .ForMember(e => e.Site, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.SeedTrays, opt => opt.Ignore());

            CreateMap<PlantSeedSite, Site>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.SeedBatches, opt => opt.Ignore());

            CreateMap<PlantSeedTray, SeedTray>()
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.SeedBatch, opt => opt.Ignore())
                .ForMember(e => e.ObjectState, opt => opt.Ignore());

            CreateMap<PlantStockEntry, PlantStock>()
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.ProductType, opt => opt.Ignore())
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
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<PlantProductType, ProductType>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.ProductPrices, opt => opt.Ignore());

            CreateMap<PlantPriceListType, PriceListType>()
                .ForMember(e => e.ObjectState, opt => opt.Ignore())
                .ForMember(e => e.ProductPrices, opt => opt.Ignore());
            */
        }
    }
}