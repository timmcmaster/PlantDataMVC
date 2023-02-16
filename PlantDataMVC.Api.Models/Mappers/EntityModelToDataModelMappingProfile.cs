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
            ConfigureEntityModelToDataModel();
        }

        /// <summary>
        ///     Configure the mappings from the DAL objects to the DTOs
        /// </summary>
        private void ConfigureEntityModelToDataModel()
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
            ConfigurePriceListTypeMappings();
            ConfigureProductPriceMappings();
        }

        private void ConfigureGenusMappings()
        {
            // Do this explicitly for now to show what is mapped
            CreateMap<GenusEntityModel, GenusDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
                .ForMember(dm => dm.Species, opt => opt.MapFrom(e => e.Species)); // ICollection, explicit and unnecessary

            //CreateMap<Genus, GenusInListDataModel>()
            //    .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
            //    .ForMember(dm => dm.LatinName, opt => opt.MapFrom(e => e.LatinName)) // explicit and unnecessary
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSpeciesMappings()
        {
            CreateMap<SpeciesEntityModel, SpeciesDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
                .ForMember(dm => dm.GenusName, opt => opt.MapFrom(e => e.Genus.LatinName))
                .ForMember(dm => dm.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
                .ForMember(dm => dm.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
                .ForMember(dm => dm.Description, opt => opt.MapFrom(e => e.Description)) // explicit and unnecessary
                .ForMember(dm => dm.Native, opt => opt.MapFrom(e => e.Native)) // explicit and unnecessary
                .ForMember(dm => dm.PropagationTime, opt => opt.MapFrom(e => e.PropagationTime)) // explicit and unnecessary
                .ForMember(dm => dm.SeedBatches, opt =>
                {
                    opt.MapFrom(e => e.SeedBatches);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }) // ICollection, explicit and unnecessary
                .ForMember(dm => dm.PlantStocks, opt =>
                {
                    opt.MapFrom(e => e.PlantStocks);
                    opt.ExplicitExpansion(); // For projections only expand collection if requested
                }); // ICollection, explicit and unnecessary

            //CreateMap<Species, SpeciesInListDataModel>()
            //    .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
            //    .ForMember(dm => dm.GenusId, opt => opt.MapFrom(e => e.GenusId)) // explicit and unnecessary
            //    .ForMember(dm => dm.CommonName, opt => opt.MapFrom(e => e.CommonName)) // explicit and unnecessary
            //    .ForMember(dm => dm.SpecificName, opt => opt.MapFrom(e => e.SpecificName)) // explicit and unnecessary
            //    .ForMember(dm => dm.Binomial, opt => opt.MapFrom(e => e.Binomial)) // explicit and unnecessary
            //    .ForAllOtherMembers(opt => opt.Ignore());
        }

        private void ConfigureSeedBatchMappings()
        {
            CreateMap<SeedBatchEntityModel, SeedBatchDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dm => dm.GenusName, opt => opt.MapFrom(e => e.Species.Genus.LatinName))
                .ForMember(dm => dm.SpeciesName, opt => opt.MapFrom(e => e.Species.SpecificName))
                .ForMember(dm => dm.DateCollected, opt => opt.MapFrom(e => e.DateCollected)) // explicit and unnecessary
                .ForMember(dm => dm.Location, opt => opt.MapFrom(e => e.Location)) // explicit and unnecessary
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(e => e.Notes)) // explicit and unnecessary
                .ForMember(dm => dm.SiteId, opt => opt.MapFrom(e => e.SiteId)) // explicit and unnecessary
                .ForMember(dm => dm.SiteName, opt => opt.MapFrom(e => e.Site.SiteName))
                .ForMember(dm => dm.SeedTrays, opt => opt.MapFrom(e => e.SeedTrays)); // ICollection, explicit and unnecessary
        }

        private void ConfigureSiteMappings()
        {
            CreateMap<SiteEntityModel, SiteDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.SiteName, opt => opt.MapFrom(e => e.SiteName)) // explicit and unnecessary
                .ForMember(dm => dm.Suburb, opt => opt.MapFrom(e => e.Suburb)) // explicit and unnecessary
                .ForMember(dm => dm.Latitude, opt => opt.MapFrom(e => e.Latitude)) // explicit and unnecessary
                .ForMember(dm => dm.Longitude, opt => opt.MapFrom(e => e.Longitude)) // explicit and unnecessary
                .ForMember(dm => dm.SeedBatches, opt => opt.MapFrom(e => e.SeedBatches)); // ICollection, explicit and unnecessary
        }

        private void ConfigureSeedTrayMappings()
        {
            CreateMap<SeedTrayEntityModel, SeedTrayDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.SeedBatchId, opt => opt.MapFrom(e => e.SeedBatchId)) // explicit and unnecessary
                .ForMember(dm => dm.SeedBatchGenusName, opt => opt.MapFrom(e => e.SeedBatch.Species.Genus.LatinName))
                .ForMember(dm => dm.SeedBatchSpeciesName, opt => opt.MapFrom(e => e.SeedBatch.Species.SpecificName))
                .ForMember(dm => dm.SeedBatchDateCollected, opt => opt.MapFrom(e => e.SeedBatch.DateCollected))
                .ForMember(dm => dm.SeedBatchLocation, opt => opt.MapFrom(e => e.SeedBatch.Location))
                .ForMember(dm => dm.DateSown, opt => opt.MapFrom(e => e.DatePlanted)) // explicit and unnecessary
                .ForMember(dm => dm.Treatment, opt => opt.MapFrom(e => e.Treatment)) // explicit and unnecessary
                .ForMember(dm => dm.ThrownOut, opt => opt.MapFrom(e => e.ThrownOut)) // explicit and unnecessary
                .ForMember(dm => dm.JournalEntries, opt => opt.MapFrom(e => e.JournalEntries)); // ICollection, explicit and unnecessary
        }

        private void ConfigurePlantStockMappings()
        {
            CreateMap<PlantStockEntityModel, PlantStockDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dm => dm.GenusName, opt => opt.MapFrom(e => e.Species.Genus.LatinName))
                .ForMember(dm => dm.SpeciesName, opt => opt.MapFrom(e => e.Species.SpecificName))
                .ForMember(dm => dm.ProductTypeId, opt => opt.MapFrom(e => e.ProductTypeId)) // explicit and unnecessary
                .ForMember(dm => dm.ProductTypeName, opt => opt.MapFrom(e => e.ProductType.Name))
                .ForMember(dm => dm.QuantityInStock, opt => opt.MapFrom(e => e.QuantityInStock)); // explicit and unnecessary
        }

        private void ConfigureJournalEntryMappings()
        {
            CreateMap<JournalEntryEntityModel, JournalEntryDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(e => e.SpeciesId)) // explicit and unnecessary
                .ForMember(dm => dm.ProductTypeId, opt => opt.MapFrom(e => e.ProductTypeId)) // explicit and unnecessary
                .ForMember(dm => dm.JournalEntryTypeId, opt => opt.MapFrom(e => e.JournalEntryTypeId)) // explicit and unnecessary
                .ForMember(dm => dm.JournalEntryTypeName, opt => opt.MapFrom(e => e.JournalEntryType.Name)) // explicit and unnecessary
                .ForMember(dm => dm.TransactionDate, opt => opt.MapFrom(e => e.TransactionDate)) // explicit and unnecessary
                .ForMember(dm => dm.Quantity, opt => opt.MapFrom(e => e.Quantity)) // explicit and unnecessary
                .ForMember(dm => dm.SeedTrayId, opt => opt.MapFrom(e => e.SeedTrayId)) // explicit and unnecessary
                .ForMember(dm => dm.Source, opt => opt.MapFrom(e => e.Source)) // explicit and unnecessary
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(e => e.Notes)); // explicit and unnecessary
        }

        private void ConfigureJournalEntryTypeMappings()
        {
            CreateMap<JournalEntryTypeEntityModel, JournalEntryTypeDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dm => dm.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(dm => dm.Effect, opt => opt.MapFrom(e => e.Effect));
        }

        private void ConfigureProductTypeMappings()
        {
            CreateMap<ProductTypeEntityModel, ProductTypeDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dm => dm.Name, opt => opt.MapFrom(e => e.Name));
        }

        private void ConfigureSaleEventMappings()
        {
            CreateMap<SaleEventEntityModel, SaleEventDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id)) // explicit and unnecessary
                .ForMember(dm => dm.Name, opt => opt.MapFrom(e => e.Name)) // explicit and unnecessary
                .ForMember(dm => dm.SaleDate, opt => opt.MapFrom(e => e.SaleDate)) // explicit and unnecessary
                .ForMember(dm => dm.Location, opt => opt.MapFrom(e => e.Location)); // explicit and unnecessary
        }

        private void ConfigurePriceListTypeMappings()
        {
            CreateMap<PriceListTypeEntityModel, PriceListTypeDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dm => dm.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(dm => dm.Kind, opt => opt.MapFrom(e => e.Kind))
                .ForMember(dm => dm.ProductPrices, opt => opt.MapFrom(e => e.ProductPrices));  // ICollection, explicit and unnecessary
        }

        private void ConfigureProductPriceMappings()
        {
            CreateMap<ProductPriceEntityModel, ProductPriceDataModel>()
                .ForMember(dm => dm.ProductTypeId, opt => opt.MapFrom(e => e.ProductTypeId))
                .ForMember(dm => dm.PriceListTypeId, opt => opt.MapFrom(e => e.PriceListTypeId))
                .ForMember(dm => dm.Price, opt => opt.MapFrom(e => e.Price))
                .ForMember(dm => dm.DateEffective, opt => opt.MapFrom(e => e.DateEffective));
        }
        // Not yet mapped objects
    }
}
