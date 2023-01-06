using AutoMapper;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Api.Models.Mappers
{
    public class EntityModelToDataModelMappingProfile : Profile
    {
        public EntityModelToDataModelMappingProfile()
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
            ConfigureProductTypeMappings();
            ConfigureJournalEntryTypeMappings();
            ConfigureSaleEventMappings();
        }

        private void ConfigureGenusMappings()
        {
            // Do this explicitly for now to show what is mapped
            CreateMap<GenusEntityModel, GenusDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
                .ForMember(dto => dto.Species, opt => opt.MapFrom(e => e.Species)); // ICollection, explicit and unnecessary

            //CreateMap<Genus, GenusInListDto>()
            //    .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
            //    .ForMember(dto => dto.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSpeciesMappings()
        {
            CreateMap<SpeciesEntityModel, SpeciesDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
                .ForMember(dto => dto.GenusName, opt => opt.MapFrom(e => e.Genus.LatinName))
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
                .ForMember(dto => dto.Description, opt => opt.MapFrom(e => e.Description)) // explicit and unnecessary
                .ForMember(dto => dto.Native, opt => opt.MapFrom(e => e.Native)) // explicit and unnecessary
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(e => e.PropagationTime)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatches, opt =>
                {
                    opt.MapFrom(e => e.SeedBatches);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }) // ICollection, explicit and unnecessary
                .ForMember(dto => dto.PlantStocks, opt =>
                {
                    opt.MapFrom(e => e.PlantStocks);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }); // ICollection, explicit and unnecessary

            //CreateMap<Species, SpeciesInListDto>()
            //    .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
            //    .ForMember(dto => dto.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
            //    .ForMember(dto => dto.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
            //    .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
            //    .ForMember(dto => dto.Binomial, opt => opt.MapFrom(e => e.Binomial)) // explicit and unnecessary
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSeedBatchMappings()
        {
            CreateMap<SeedBatchEntityModel, SeedBatchDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dto => dto.GenusName, opt => opt.MapFrom(e => e.Species.Genus.LatinName))
                .ForMember(dto => dto.SpeciesName, opt => opt.MapFrom(e => e.Species.SpecificName))
                .ForMember(dto => dto.DateCollected, opt => opt.MapFrom(e => e.DateCollected)) // explicit and unnecessary
                .ForMember(dto => dto.Location, opt => opt.MapFrom(e => e.Location)) // explicit and unnecessary
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(e => e.Notes)) // explicit and unnecessary
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(e => e.SiteId)) // explicit and unnecessary
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(e => e.Site.SiteName))
                .ForMember(dto => dto.SeedTrays, opt => opt.MapFrom(e => e.SeedTrays)); // ICollection, explicit and unnecessary
        }

        private void ConfigureSiteMappings()
        {
            CreateMap<SiteEntityModel, SiteDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(e => e.SiteName)) // explicit and unnecessary
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(e => e.Suburb)) // explicit and unnecessary
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(e => e.Latitude)) // explicit and unnecessary
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(e => e.Longitude)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatches, opt => opt.MapFrom(e => e.SeedBatches)); // ICollection, explicit and unnecessary
        }

        private void ConfigureSeedTrayMappings()
        {
            CreateMap<SeedTrayEntityModel, SeedTrayDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(e => e.SeedBatchId)) // explicit and unnecessary
                .ForMember(dto => dto.GenusName, opt => opt.MapFrom(e => e.SeedBatch.Species.Genus.LatinName))
                .ForMember(dto => dto.SpeciesName, opt => opt.MapFrom(e => e.SeedBatch.Species.SpecificName))
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(e => e.DatePlanted)) // explicit and unnecessary
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(e => e.Treatment)) // explicit and unnecessary
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(e => e.ThrownOut)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntries, opt => opt.MapFrom(e => e.JournalEntries)); // ICollection, explicit and unnecessary
        }

        private void ConfigurePlantStockMappings()
        {
            CreateMap<PlantStockEntityModel, PlantStockDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dto => dto.GenusName, opt => opt.MapFrom(e => e.Species.Genus.LatinName))
                .ForMember(dto => dto.SpeciesName, opt => opt.MapFrom(e => e.Species.SpecificName))
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(e => e.ProductTypeId)) // explicit and unnecessary
                .ForMember(dto => dto.ProductTypeName, opt => opt.MapFrom(e => e.ProductType.Name))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(e => e.QuantityInStock)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntries, opt => opt.MapFrom(e => e.JournalEntries)); // ICollection, explicit and unnecessary
        }

        private void ConfigureJournalEntryMappings()
        {
            CreateMap<JournalEntryEntityModel, JournalEntryDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(e => e.PlantStockId)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(e => e.JournalEntryTypeId)) // explicit and unnecessary
                .ForMember(dto => dto.JournalEntryTypeName, opt => opt.MapFrom(e => e.JournalEntryType.Name)) // explicit and unnecessary
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(e => e.TransactionDate)) // explicit and unnecessary
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(e => e.Quantity)) // explicit and unnecessary
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(e => e.SeedTrayId)) // explicit and unnecessary
                .ForMember(dto => dto.Source, opt => opt.MapFrom(e => e.Source)) // explicit and unnecessary
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(e => e.Notes)); // explicit and unnecessary
        }

        private void ConfigureJournalEntryTypeMappings()
        {
            CreateMap<JournalEntryTypeEntityModel, JournalEntryTypeDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(dto => dto.Effect, opt => opt.MapFrom(e => e.Effect));
        }

        private void ConfigureProductTypeMappings()
        {
            CreateMap<ProductTypeEntityModel, ProductTypeDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.Name));
        }

        private void ConfigureSaleEventMappings()
        {
            CreateMap<SaleEventEntityModel, SaleEventDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.Name)) // explicit and unnecessary
                .ForMember(dto => dto.SaleDate, opt => opt.MapFrom(e => e.SaleDate)) // explicit and unnecessary
                .ForMember(dto => dto.Location, opt => opt.MapFrom(e => e.Location)); // explicit and unnecessary
        }

        // Not yet mapped objects
        //JournalEntryType => JournalEntryTypeDTO
        //PriceListType => PriceListTypeDTO
        //ProductPrice => ProductPriceDTO
    }
}
