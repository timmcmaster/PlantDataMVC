using AutoMapper;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Api.Models.Mappers
{
    public class DataModelToEntityModelMappingProfile : Profile
    {
        public DataModelToEntityModelMappingProfile()
        {
            ConfigureDataModelToEntityModel();
        }

        /// <summary>
        ///     Configure the mappings from the App/Business Layer objects to the DAL objects
        /// </summary>
        private void ConfigureDataModelToEntityModel()
        {
            // Maps from Data Layer entities to DataModel
            ConfigureGenusMappings();
            ConfigureSpeciesMappings();
            ConfigureJournalEntryMappings();
            ConfigurePlantStockMappings();
            ConfigureSeedBatchMappings();
            ConfigureSeedTrayMappings();
            ConfigureSiteMappings();
            ConfigureSaleEventMappings();
            ConfigureProductTypeMappings();
        }

        private void ConfigureGenusMappings()
        {
            // TODO: Suggestions from web that it is not good practice to map downwards - read why, then fix
            // see https://jens.gheerardyn.be/why-using-automapper-for-dto-to-entity-mapping-is-a-bad-idea/

            // Note - default behavior for collections is to map null object to empty collection

            CreateMap<CreateUpdateGenusDataModel, GenusEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.LatinName, opt => opt.MapFrom(dm => dm.LatinName)) // explicit and unnecessary
                .ForMember(e => e.Species, opt => opt.Ignore());

            CreateMap<GenusDataModel, GenusEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.LatinName, opt => opt.MapFrom(dm => dm.LatinName)) // explicit and unnecessary
                .ForMember(e => e.Species, opt => opt.MapFrom(dm => dm.Species)); // ICollection, explicit and unnecessary 
        }

        private void ConfigureSpeciesMappings()
        {
            CreateMap<CreateUpdateSpeciesDataModel, SpeciesEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.GenusId, opt => opt.MapFrom(dm => dm.GenusId)) // explicit and unnecessary
                .ForMember(e => e.SpecificName, opt => opt.MapFrom(dm => dm.SpecificName)) // explicit and unnecessary
                .ForMember(e => e.CommonName, opt => opt.MapFrom(dm => dm.CommonName)) // explicit and unnecessary
                .ForMember(e => e.Description, opt => opt.MapFrom(dm => dm.Description)) // explicit and unnecessary
                .ForMember(e => e.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime)) // explicit and unnecessary
                .ForMember(e => e.Native, opt => opt.MapFrom(dm => dm.Native)) // explicit and unnecessary
                .ForMember(e => e.PlantStocks, opt => opt.Ignore())
                .ForMember(e => e.SeedBatches, opt => opt.Ignore())
                .ForMember(e => e.Genus, opt => opt.Ignore());

            CreateMap<SpeciesDataModel, SpeciesEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.GenusId, opt => opt.MapFrom(dm => dm.GenusId)) // explicit and unnecessary
                .ForMember(e => e.SpecificName, opt => opt.MapFrom(dm => dm.SpecificName)) // explicit and unnecessary
                .ForMember(e => e.CommonName, opt => opt.MapFrom(dm => dm.CommonName)) // explicit and unnecessary
                .ForMember(e => e.Description, opt => opt.MapFrom(dm => dm.Description)) // explicit and unnecessary
                .ForMember(e => e.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime)) // explicit and unnecessary
                .ForMember(e => e.Native, opt => opt.MapFrom(dm => dm.Native)) // explicit and unnecessary
                .ForMember(e => e.SeedBatches, opt => opt.MapFrom(dm => dm.SeedBatches)) // ICollection, explicit and unnecessary
                .ForMember(e => e.PlantStocks, opt => opt.MapFrom(dm => dm.PlantStocks)) // ICollection, explicit and unnecessary
                .ForMember(e => e.Genus, opt => opt.Ignore());
        }

        private void ConfigureSeedBatchMappings()
        {
            CreateMap<CreateUpdateSeedBatchDataModel, SeedBatchEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId)) // explicit and unnecessary
                .ForMember(e => e.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected)) // explicit and unnecessary
                .ForMember(e => e.Location, opt => opt.MapFrom(dm => dm.Location)) // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dm => dm.Notes)) // explicit and unnecessary
                .ForMember(e => e.SiteId, opt => opt.MapFrom(dm => dm.SiteId)) // explicit and unnecessary
                .ForMember(e => e.SeedTrays, opt => opt.Ignore())
                .ForMember(e => e.Site, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore());

            CreateMap<SeedBatchDataModel, SeedBatchEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId)) // explicit and unnecessary
                .ForMember(e => e.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected)) // explicit and unnecessary
                .ForMember(e => e.Location, opt => opt.MapFrom(dm => dm.Location)) // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dm => dm.Notes)) // explicit and unnecessary
                .ForMember(e => e.SiteId, opt => opt.MapFrom(dm => dm.SiteId)) // explicit and unnecessary
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId)) // explicit and unnecessary
                .ForMember(e => e.SeedTrays, opt => opt.MapFrom(dm => dm.SeedTrays)) // ICollection, explicit and unnecessary
                .ForMember(e => e.Site, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore());
        }

        private void ConfigureSiteMappings()
        {
            CreateMap<CreateUpdateSiteDataModel, SiteEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.SiteName, opt => opt.MapFrom(dm => dm.SiteName)) // explicit and unnecessary
                .ForMember(e => e.Suburb, opt => opt.MapFrom(dm => dm.Suburb)) // explicit and unnecessary
                .ForMember(e => e.Latitude, opt => opt.MapFrom(dm => dm.Latitude)) // explicit and unnecessary
                .ForMember(e => e.Longitude, opt => opt.MapFrom(dm => dm.Longitude)) // explicit and unnecessary
                .ForMember(e => e.SeedBatches, opt => opt.Ignore());

            CreateMap<SiteDataModel, SiteEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.SiteName, opt => opt.MapFrom(dm => dm.SiteName)) // explicit and unnecessary
                .ForMember(e => e.Suburb, opt => opt.MapFrom(dm => dm.Suburb)) // explicit and unnecessary
                .ForMember(e => e.Latitude, opt => opt.MapFrom(dm => dm.Latitude)) // explicit and unnecessary
                .ForMember(e => e.Longitude, opt => opt.MapFrom(dm => dm.Longitude)) // explicit and unnecessary
                .ForMember(e => e.SeedBatches, opt => opt.MapFrom(dm => dm.SeedBatches)); // ICollection, explicit and unnecessary
        }

        private void ConfigureSeedTrayMappings()
        {
            CreateMap<CreateUpdateSeedTrayDataModel, SeedTrayEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId)) // explicit and unnecessary
                .ForMember(e => e.DatePlanted, opt => opt.MapFrom(dm => dm.DateSown)) // explicit and unnecessary
                .ForMember(e => e.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut)) // explicit and unnecessary
                .ForMember(e => e.Treatment, opt => opt.MapFrom(dm => dm.Treatment)) // explicit and unnecessary
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.SeedBatch, opt => opt.Ignore());

            CreateMap<SeedTrayDataModel, SeedTrayEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId)) // explicit and unnecessary
                .ForMember(e => e.DatePlanted, opt => opt.MapFrom(dm => dm.DateSown)) // explicit and unnecessary
                .ForMember(e => e.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut)) // explicit and unnecessary
                .ForMember(e => e.Treatment, opt => opt.MapFrom(dm => dm.Treatment)) // explicit and unnecessary
                .ForMember(e => e.JournalEntries, opt => opt.MapFrom(dm => dm.JournalEntries)) // ICollection, explicit and unnecessary
                .ForMember(e => e.SeedBatch, opt => opt.Ignore());
        }

        private void ConfigurePlantStockMappings()
        {
            CreateMap<CreateUpdatePlantStockDataModel, PlantStockEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId)) // explicit and unnecessary
                .ForMember(e => e.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId)) // explicit and unnecessary
                .ForMember(e => e.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock)) // explicit and unnecessary
                .ForMember(e => e.JournalEntries, opt => opt.Ignore())
                .ForMember(e => e.ProductType, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore());

            CreateMap<PlantStockDataModel, PlantStockEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId)) // explicit and unnecessary
                .ForMember(e => e.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId)) // explicit and unnecessary
                .ForMember(e => e.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock)) // explicit and unnecessary
                .ForMember(e => e.JournalEntries, opt => opt.MapFrom(dm => dm.JournalEntries)) // ICollection, explicit and unnecessary
                .ForMember(e => e.ProductType, opt => opt.Ignore())
                .ForMember(e => e.Species, opt => opt.Ignore());
        }

        private void ConfigureJournalEntryMappings()
        {
            CreateMap<CreateUpdateJournalEntryDataModel, JournalEntryEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom(dm => dm.PlantStockId)) // explicit and unnecessary
                .ForMember(e => e.Quantity, opt => opt.MapFrom(dm => dm.Quantity)) // explicit and unnecessary
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId)) // explicit and unnecessary
                .ForMember(e => e.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate)) // explicit and unnecessary
                .ForMember(e => e.Source, opt => opt.MapFrom(dm => dm.Source)) // explicit and unnecessary
                .ForMember(e => e.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId)) // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dm => dm.Notes)) // explicit and unnecessary
                .ForMember(e => e.JournalEntryType, opt => opt.Ignore())
                .ForMember(e => e.PlantStock, opt => opt.Ignore())
                .ForMember(e => e.SeedTray, opt => opt.Ignore());

            CreateMap<JournalEntryDataModel, JournalEntryEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.PlantStockId, opt => opt.MapFrom(dm => dm.PlantStockId)) // explicit and unnecessary
                .ForMember(e => e.Quantity, opt => opt.MapFrom(dm => dm.Quantity)) // explicit and unnecessary
                .ForMember(e => e.JournalEntryTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId)) // explicit and unnecessary
                .ForMember(e => e.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate)) // explicit and unnecessary
                .ForMember(e => e.Source, opt => opt.MapFrom(dm => dm.Source)) // explicit and unnecessary
                .ForMember(e => e.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId)) // explicit and unnecessary
                .ForMember(e => e.Notes, opt => opt.MapFrom(dm => dm.Notes)) // explicit and unnecessary
                .ForMember(e => e.JournalEntryType, opt => opt.Ignore())
                .ForMember(e => e.PlantStock, opt => opt.Ignore())
                .ForMember(e => e.SeedTray, opt => opt.Ignore());
        }

        private void ConfigureSaleEventMappings()
        {
            CreateMap<CreateUpdateSaleEventDataModel, SaleEventEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Name, opt => opt.MapFrom(dm => dm.Name)) // explicit and unnecessary
                .ForMember(e => e.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate)) // explicit and unnecessary
                .ForMember(e => e.Location, opt => opt.MapFrom(dm => dm.Location)); // explicit and unnecessary

            CreateMap<SaleEventDataModel, SaleEventEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.Name, opt => opt.MapFrom(dm => dm.Name)) // explicit and unnecessary
                .ForMember(e => e.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate)) // explicit and unnecessary
                .ForMember(e => e.Location, opt => opt.MapFrom(dm => dm.Location)); // explicit and unnecessary
        }

        private void ConfigureProductTypeMappings()
        {
            CreateMap<CreateUpdateProductTypeDataModel, ProductTypeEntityModel>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Name, opt => opt.MapFrom(dm => dm.Name)); // explicit and unnecessary

            CreateMap<ProductTypeDataModel, ProductTypeEntityModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dm => dm.Id)) // explicit and unnecessary
                .ForMember(e => e.Name, opt => opt.MapFrom(dm => dm.Name)); // explicit and unnecessary
        }
        // Not yet mapped objects
        //JournalEntryTypeDataModel => JournalEntryTypeEntityModel
        //PriceListTypeDataModel => PriceListTypeEntityModel
        //ProductPriceDataModel => ProductPriceEntityModel
    }
}