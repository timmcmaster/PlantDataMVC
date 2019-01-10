using AutoMapper;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.DTO.Mappers
{
    public class EFDALToDTOMappingProfile : Profile
    {
        public EFDALToDTOMappingProfile()
        {
            ConfigureDALToDTO();
        }

        /// <summary>
        /// Configure the mappings from the DAL objects to the DTOs
        /// </summary>
        private void ConfigureDALToDTO()
        {
            // Maps from Data Layer entities to DTO

            CreateMap<Genus, GenusDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))                    // explicit and unnecessary
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(e => e.LatinName))      // explicit and unnecessary
                .ForMember(dto => dto.DisplayValue, opt => opt.MapFrom(e => e.LatinName));  // explicit, necessary

            CreateMap<Species, SpeciesDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))                    // explicit and unnecessary
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(e => e.GenusId))      // explicit and unnecessary
                .ForMember(dto => dto.DisplayValue, opt => opt.MapFrom(e => e.LatinName));  // explicit, necessary
            /*
            CreateMap<SeedBatch, PlantSeed>()
                .ForMember(bo => bo.SiteName, opt => opt.MapFrom(e => e.Site.SiteName));
                //.ForMember(bo => bo.SeedTrays, opt => opt.MapFrom<SeedTray[]>(e => e.SeedTrays.ToArray()));

            CreateMap<Site, PlantSeedSite>();
                //.ForMember(bo => bo.SeedBatches, opt => opt.MapFrom<SeedBatch[]>(e => e.SeedBatches.ToArray()));

            CreateMap<SeedTray, PlantSeedTray>();
                //.ForMember(bo => bo.PlantStockTransactions, opt => opt.Ignore());
                //.ForMember(bo => bo.PlantStockTransactions, opt => opt.MapFrom<JournalEntry[]>(e => e.JournalEntries.ToArray()));

            CreateMap<PlantStock, PlantStockEntry>();
                //.ForMember(bo => bo.Transactions, opt => opt.Ignore());

            CreateMap<JournalEntry, PlantStockTransaction>()
                .ForMember(bo => bo.PlantStockEntryId, opt => opt.MapFrom(e => e.PlantStockId))
                .ForMember(bo => bo.TransactionType, opt => opt.MapFrom(e => e.JournalEntryType))
                .ForMember(bo => bo.TransactionSource, opt => opt.MapFrom(e => e.Source));

            CreateMap<JournalEntryType, PlantStockTransactionType>();

            CreateMap<ProductPrice, PlantProductPrice>();

            CreateMap<ProductType, PlantProductType>();

            CreateMap<PriceListType, PlantPriceListType>();
            */
        }
    }
}