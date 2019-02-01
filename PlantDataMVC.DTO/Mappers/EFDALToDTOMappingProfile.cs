using AutoMapper;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.DTO.Mappers
{
    public class EfDalToDtoMappingProfile : Profile
    {
        public EfDalToDtoMappingProfile()
        {
            ConfigureDalToDto();
        }

        /// <summary>
        ///     Configure the mappings from the DAL objects to the DTOs
        /// </summary>
        private void ConfigureDalToDto()
        {
            // Maps from Data Layer entities to DTO
            ConfigureGenusMappings();
            ConfigureSpeciesMappings();
            ConfigureJournalEntryMappings();
            ConfigurePlantStockMappings();
            ConfigureSeedBatchMappings();
            ConfigureSeedTrayMappings();
            ConfigureSiteMappings();
        }


        private void ConfigureGenusMappings()
        {
            // Do this explicitly for now to show what is mapped
            CreateMap<Genus, GenusDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
                .ForMember(dto => dto.Species,
                           opt => opt.MapFrom(e => e.Species)) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Genus, GenusInListDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSpeciesMappings()
        {
            CreateMap<Species, SpeciesDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
                .ForMember(dto => dto.Description, opt => opt.MapFrom(e => e.Description)) // explicit and unnecessary
                .ForMember(dto => dto.Native, opt => opt.MapFrom(e => e.Native)) // explicit and unnecessary
                .ForMember(dto => dto.PropagationTime,
                           opt => opt.MapFrom(e => e.PropagationTime)) // explicit and unnecessary
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatches, opt =>
                {
                    opt.MapFrom(e => e.SeedBatches);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }) // ICollection, explicit and unnecessary
                .ForMember(dto => dto.PlantStocks, opt =>
                {
                    opt.MapFrom(e => e.PlantStocks);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Species, SpeciesInListDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSeedBatchMappings()
        {
            CreateMap<SeedBatch, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.DateCollected,
                           opt => opt.MapFrom(e => e.DateCollected)) // explicit and unnecessary
                .ForMember(dto => dto.Location, opt => opt.MapFrom(e => e.Location)) // explicit and unnecessary
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(e => e.Notes)) // explicit and unnecessary
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(e => e.SiteId)) // explicit and unnecessary
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dto => dto.SeedTrays,
                           opt => opt.MapFrom(e => e.SeedTrays)) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSiteMappings()
        {
            CreateMap<Site, SiteDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(e => e.Latitude)) // explicit and unnecessary
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(e => e.Longitude)) // explicit and unnecessary
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(e => e.SiteName)) // explicit and unnecessary
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(e => e.Suburb)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatches,
                           opt => opt.MapFrom(e => e.SeedBatches)) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSeedTrayMappings()
        {
            CreateMap<SeedTray, SeedTrayDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(e => e.DatePlanted)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(e => e.SeedBatchId)) // explicit and unnecessary
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(e => e.ThrownOut)) // explicit and unnecessary
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(e => e.Treatment)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntries,
                           opt => opt.MapFrom(e => e.JournalEntries)) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigurePlantStockMappings()
        {
            CreateMap<PlantStock, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.ProductTypeId,
                           opt => opt.MapFrom(e => e.ProductTypeId)) // explicit and unnecessary
                .ForMember(dto => dto.QuantityInStock,
                           opt => opt.MapFrom(e => e.QuantityInStock)) // explicit and unnecessary
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntries,
                           opt => opt.MapFrom(e => e.JournalEntries)) // ICollection, explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureJournalEntryMappings()
        {
            CreateMap<JournalEntry, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntryTypeId,
                           opt => opt.MapFrom(e => e.JournalEntryTypeId)) // explicit and unnecessary
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(e => e.Notes)) // explicit and unnecessary
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(e => e.PlantStockId)) // explicit and unnecessary
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(e => e.Quantity)) // explicit and unnecessary
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(e => e.SeedTrayId)) // explicit and unnecessary
                .ForMember(dto => dto.Source, opt => opt.MapFrom(e => e.Source)) // explicit and unnecessary
                .ForMember(dto => dto.TransactionDate,
                           opt => opt.MapFrom(e => e.TransactionDate)) // explicit and unnecessary
                .ForAllOtherMembers(opt => opt.Ignore());
        }

        // Not yet mapped objects
        //JournalEntryType => JournalEntryTypeDTO
        //PriceListType => PriceListTypeDTO
        //ProductPrice => ProductPriceDTO
        //ProductType => ProductTypeDTO
    }
}