using AutoMapper;
using PlantDataMVC.Entities.Models;
using System;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.DTO.Mappers
{
    public class EfDtoToDalMappingProfile: Profile
    {
        public EfDtoToDalMappingProfile()
        {
            ConfigureDTOToDAL();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the DAL objects
        /// </summary>
        private void ConfigureDTOToDAL()
        {
            // TODO: Suggestions from web that it is not good practice to map downwards - read why, then fix

            // Note - default behavior for collections is to map null object to empty collection

            CreateMap<CreateUpdateGenusDto, Genus>()
                .ForMember(e => e.LatinName, opt => opt.MapFrom(dto => dto.LatinName))      // explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<GenusDto, Genus>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                    // explicit and unnecessary
                .ForMember(e => e.LatinName, opt => opt.MapFrom(dto => dto.LatinName))      // explicit and unnecessary
                .ForMember(e => e.Species, opt => opt.MapFrom(dto => dto.Species))          // ICollection, explicit and unnecessary 
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SpeciesDto, Species>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                            // explicit and unnecessary
                .ForMember(e => e.GenusId, opt => opt.MapFrom(dto => dto.GenusId))                  // explicit and unnecessary
                .ForMember(e => e.CommonName, opt => opt.MapFrom(dto => dto.CommonName))            // explicit and unnecessary
                .ForMember(e => e.Description, opt => opt.MapFrom(dto => dto.Description))          // explicit and unnecessary
                .ForMember(e => e.Native, opt => opt.MapFrom(dto => dto.Native))                    // explicit and unnecessary
                .ForMember(e => e.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))  // explicit and unnecessary
                .ForMember(e => e.SpecificName, opt => opt.MapFrom(dto => dto.SpecificName))        // explicit and unnecessary
                .ForMember(e => e.SeedBatches, opt => opt.MapFrom(dto => dto.SeedBatches))          // ICollection, explicit and unnecessary
                .ForMember(e => e.PlantStocks, opt => opt.MapFrom(dto => dto.PlantStocks))          // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SeedBatchDto, SeedBatch>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                        // explicit and unnecessary
                .ForMember(e => e.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))  // explicit and unnecessary
                .ForMember(e => e.Location, opt => opt.MapFrom(dto => dto.Location))            // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dto => dto.Notes))                  // explicit and unnecessary
                .ForMember(e => e.SiteId, opt => opt.MapFrom(dto => dto.SiteId))                // explicit and unnecessary
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))          // explicit and unnecessary
                .ForMember(e => e.SeedTrays, opt => opt.MapFrom(dto => dto.SeedTrays))          // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());


            CreateMap<SiteDto, Site>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                        // explicit and unnecessary
                .ForMember(e => e.Latitude, opt => opt.MapFrom(dto => dto.Latitude))            // explicit and unnecessary
                .ForMember(e => e.Longitude, opt => opt.MapFrom(dto => dto.Longitude))          // explicit and unnecessary
                .ForMember(e => e.SiteName, opt => opt.MapFrom(dto => dto.SiteName))            // explicit and unnecessary
                .ForMember(e => e.Suburb, opt => opt.MapFrom(dto => dto.Suburb))                // explicit and unnecessary
                .ForMember(e => e.SeedBatches, opt => opt.MapFrom(dto => dto.SeedBatches))     // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SeedTrayDto, SeedTray>()
               .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                            // explicit and unnecessary
               .ForMember(e => e.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))          // explicit and unnecessary
               .ForMember(e => e.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))          // explicit and unnecessary
               .ForMember(e => e.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))              // explicit and unnecessary
               .ForMember(e => e.Treatment, opt => opt.MapFrom(dto => dto.Treatment))              // explicit and unnecessary
               .ForMember(e => e.JournalEntries, opt => opt.MapFrom(dto => dto.JournalEntries))    // ICollection, explicit and unnecessary
               .ForAllOtherMembers(opt => opt.Ignore());


            CreateMap<PlantStockDto, PlantStock>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                            // explicit and unnecessary
                .ForMember(e => e.ProductTypeId, opt => opt.MapFrom(dto => dto.ProductTypeId))      // explicit and unnecessary
                .ForMember(e => e.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))  // explicit and unnecessary
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))              // explicit and unnecessary
                .ForMember(e => e.JournalEntries, opt => opt.MapFrom(dto => dto.JournalEntries))    // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<JournalEntryDto, JournalEntry>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))                                    // explicit and unnecessary
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom(dto => dto.JournalEntryTypeId))    // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dto => dto.Notes))                              // explicit and unnecessary
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))                // explicit and unnecessary
                .ForMember(e => e.Quantity, opt => opt.MapFrom(dto => dto.Quantity))                        // explicit and unnecessary
                .ForMember(e => e.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))                    // explicit and unnecessary
                .ForMember(e => e.Source, opt => opt.MapFrom(dto => dto.Source))                            // explicit and unnecessary
                .ForMember(e => e.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))          // explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            // Not yet mapped objects
            //JournalEntryTypeDTO => JournalEntryType
            //PriceListTypeDTO => PriceListType
            //ProductPriceDTO => ProductPrice
            //ProductTypeDTO => ProductType
        }
    }
}