using AutoMapper;
using PlantDataMVC.Api.Models.DataModels;
using Genus = PlantDataMVC.Web.Models.EditModels.Genus;
using Plant = PlantDataMVC.Web.Models.EditModels.Plant;
using PlantStock = PlantDataMVC.Web.Models.EditModels.PlantStock;
using ProductType = PlantDataMVC.Web.Models.EditModels.ProductType;
using PriceListType = PlantDataMVC.Web.Models.EditModels.PriceListType;
using SaleEvent = PlantDataMVC.Web.Models.EditModels.SaleEvent;
using SeedBatch = PlantDataMVC.Web.Models.EditModels.SeedBatch;
using SeedTray = PlantDataMVC.Web.Models.EditModels.SeedTray;
using Site = PlantDataMVC.Web.Models.EditModels.Site;
using Transaction = PlantDataMVC.Web.Models.EditModels.Transaction;

namespace PlantDataMVC.Web.Mappers
{
    public class UIToDataModelMappingProfile : Profile
    {
        public UIToDataModelMappingProfile()
        {
            ConfigureEditModelsToDataModel();
        }

        /// <summary>
        /// Configure the mappings from the UI layer edit models to the App/Business Layer objects
        /// </summary>
        private void ConfigureEditModelsToDataModel()
        {
            ConfigureGenusEditModels();
            ConfigurePlantEditModels();
            ConfigureSeedBatchEditModels();
            ConfigureSeedTrayEditModels();
            ConfigurePlantStockEditModels();
            ConfigureProductTypeEditModels();
            ConfigureTransactionEditModels();
            ConfigureSiteEditModels();
            ConfigureSaleEventEditModels();
            ConfigurePriceListTypeEditModels();
            // Maps from UI edit models to domain
        }

        #region Configure Edit Models

        private void ConfigureGenusEditModels()
        {
            // Plant
            CreateMap<Genus.GenusCreateEditModel, CreateUpdateGenusDataModel>()
                .ForMember(dm => dm.LatinName, opt => opt.MapFrom(uio => uio.LatinName));

            CreateMap<Genus.GenusDestroyEditModel, GenusDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.LatinName, opt => opt.Ignore())
                .ForMember(dm => dm.Species, opt => opt.Ignore());

            CreateMap<Genus.GenusUpdateEditModel, CreateUpdateGenusDataModel>()
                .ForMember(dm => dm.LatinName, opt => opt.MapFrom(uio => uio.LatinName));

            //CreateMap<GenusUpdateEditModel, GenusDataModel>()
            //    .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
            //    .ForMember(dm => dm.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
            //    .ForMember(dm => dm.Species, opt => opt.Ignore());     // TODO: check about mapping back collection
        }

        private void ConfigurePlantEditModels()
        {
            // Plant
             CreateMap<Plant.PlantCreateEditModel, CreateUpdateSpeciesDataModel>()
                .ForMember(dm => dm.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dm => dm.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dm => dm.GenusId, opt => opt.MapFrom(uio => uio.GenusId))
                .ForMember(dm => dm.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dm => dm.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dm => dm.SpecificName, opt => opt.MapFrom(uio => uio.Species));

            CreateMap<Plant.PlantDestroyEditModel, SpeciesDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.GenusId, opt => opt.Ignore())
                .ForMember(dm => dm.GenusName, opt => opt.Ignore())
                .ForMember(dm => dm.SpecificName, opt => opt.Ignore())
                .ForMember(dm => dm.CommonName, opt => opt.Ignore())
                .ForMember(dm => dm.Description, opt => opt.Ignore())
                .ForMember(dm => dm.PropagationTime, opt => opt.Ignore())
                .ForMember(dm => dm.Native, opt => opt.Ignore())
                .ForMember(dm => dm.PlantStocks, opt => opt.Ignore())
                .ForMember(dm => dm.SeedBatches, opt => opt.Ignore());

            CreateMap<Plant.PlantUpdateEditModel, CreateUpdateSpeciesDataModel>()
                .ForMember(dm => dm.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dm => dm.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dm => dm.GenusId, opt => opt.MapFrom(uio => uio.GenusId))
                .ForMember(dm => dm.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dm => dm.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dm => dm.SpecificName, opt => opt.MapFrom(uio => uio.Species));
        }

        private void ConfigureSeedBatchEditModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatch.SeedBatchCreateEditModel, CreateUpdateSeedBatchDataModel>()
                .ForMember(dm => dm.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dm => dm.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<SeedBatch.SeedBatchDestroyEditModel, SeedBatchDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.SpeciesId, opt => opt.Ignore())
                .ForMember(dm => dm.GenusName, opt => opt.Ignore())
                .ForMember(dm => dm.SpeciesName, opt => opt.Ignore())
                .ForMember(dm => dm.DateCollected, opt => opt.Ignore())
                .ForMember(dm => dm.Location, opt => opt.Ignore())
                .ForMember(dm => dm.Notes, opt => opt.Ignore())
                .ForMember(dm => dm.SiteId, opt => opt.Ignore())
                .ForMember(dm => dm.SiteName, opt => opt.Ignore())
                .ForMember(dm => dm.SeedTrays, opt => opt.Ignore());

        CreateMap<SeedBatch.SeedBatchUpdateEditModel, CreateUpdateSeedBatchDataModel>()
                .ForMember(dm => dm.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dm => dm.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigureSiteEditModels()
        {
            // SiteDTO
            CreateMap<Site.SiteCreateEditModel, CreateUpdateSiteDataModel>()
                .ForMember(dm => dm.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dm => dm.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dm => dm.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dm => dm.Suburb, opt => opt.MapFrom(uio => uio.Suburb));


            CreateMap<Site.SiteDestroyEditModel, SiteDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.SiteName, opt => opt.Ignore())
                .ForMember(dm => dm.Suburb, opt => opt.Ignore())
                .ForMember(dm => dm.Latitude, opt => opt.Ignore())
                .ForMember(dm => dm.Longitude, opt => opt.Ignore())
                .ForMember(dm => dm.SeedBatches, opt => opt.Ignore());

            CreateMap<Site.SiteUpdateEditModel, CreateUpdateSiteDataModel>()
                .ForMember(dm => dm.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dm => dm.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dm => dm.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dm => dm.Suburb, opt => opt.MapFrom(uio => uio.Suburb));
        }

        private void ConfigurePlantStockEditModels()
        {
            // PlantStockDTO
            CreateMap<PlantStock.PlantStockCreateEditModel, CreateUpdatePlantStockDataModel>()
                .ForMember(dm => dm.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dm => dm.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantStock.PlantStockDestroyEditModel, PlantStockDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.SpeciesId, opt => opt.Ignore())
                .ForMember(dm => dm.GenusName, opt => opt.Ignore())
                .ForMember(dm => dm.SpeciesName, opt => opt.Ignore())
                .ForMember(dm => dm.ProductTypeId, opt => opt.Ignore())
                .ForMember(dm => dm.ProductTypeName, opt => opt.Ignore())
                .ForMember(dm => dm.QuantityInStock, opt => opt.Ignore())
                .ForMember(dm => dm.JournalEntries, opt => opt.Ignore());

            CreateMap<PlantStock.PlantStockUpdateEditModel, CreateUpdatePlantStockDataModel>()
                .ForMember(dm => dm.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dm => dm.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dm => dm.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigureTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<Transaction.TransactionCreateEditModel, CreateUpdateJournalEntryDataModel>()
                .ForMember(dm => dm.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dm => dm.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dm => dm.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dm => dm.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dm => dm.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dm => dm.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));

            CreateMap<Transaction.TransactionDestroyEditModel, JournalEntryDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.PlantStockId, opt => opt.Ignore())
                .ForMember(dm => dm.JournalEntryTypeId, opt => opt.Ignore())
                .ForMember(dm => dm.JournalEntryTypeName, opt => opt.Ignore())
                .ForMember(dm => dm.TransactionDate, opt => opt.Ignore())
                .ForMember(dm => dm.Quantity, opt => opt.Ignore())
                .ForMember(dm => dm.SeedTrayId, opt => opt.Ignore())
                .ForMember(dm => dm.Source, opt => opt.Ignore())
                .ForMember(dm => dm.Notes, opt => opt.Ignore());

            CreateMap<Transaction.TransactionUpdateEditModel, CreateUpdateJournalEntryDataModel>()
                .ForMember(dm => dm.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dm => dm.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dm => dm.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dm => dm.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dm => dm.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dm => dm.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dm => dm.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));
        }

        private void ConfigureSeedTrayEditModels()
        {
            // SeedTray
            CreateMap<SeedTray.SeedTrayCreateEditModel, CreateUpdateSeedTrayDataModel>()
                .ForMember(dm => dm.DateSown, opt => opt.MapFrom(uio => uio.DateSown))
                .ForMember(dm => dm.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dm => dm.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dm => dm.Treatment, opt => opt.MapFrom(uio => uio.Treatment));

            CreateMap<SeedTray.SeedTrayDestroyEditModel, SeedTrayDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.SeedBatchId, opt => opt.Ignore())
                .ForMember(dm => dm.DateSown, opt => opt.Ignore())
                .ForMember(dm => dm.Treatment, opt => opt.Ignore())
                .ForMember(dm => dm.ThrownOut, opt => opt.Ignore())
                .ForMember(dm => dm.JournalEntries, opt => opt.Ignore());

        CreateMap<SeedTray.SeedTrayUpdateEditModel, CreateUpdateSeedTrayDataModel>()
                .ForMember(dm => dm.DateSown, opt => opt.MapFrom(uio => uio.DateSown))
                .ForMember(dm => dm.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dm => dm.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dm => dm.Treatment, opt => opt.MapFrom(uio => uio.Treatment));
        }

        private void ConfigureSaleEventEditModels()
        {
            // SaleEventDTO
            CreateMap<SaleEvent.SaleEventCreateEditModel, CreateUpdateSaleEventDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dm => dm.SaleDate, opt => opt.MapFrom(uio => uio.SaleDate))
                .ForMember(dm => dm.Location, opt => opt.MapFrom(uio => uio.Location));


            CreateMap<SaleEvent.SaleEventDestroyEditModel, SaleEventDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.Name, opt => opt.Ignore())
                .ForMember(dm => dm.SaleDate, opt => opt.Ignore())
                .ForMember(dm => dm.Location, opt => opt.Ignore());

            CreateMap<SaleEvent.SaleEventUpdateEditModel, CreateUpdateSaleEventDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dm => dm.SaleDate, opt => opt.MapFrom(uio => uio.SaleDate))
                .ForMember(dm => dm.Location, opt => opt.MapFrom(uio => uio.Location));
        }

        private void ConfigureProductTypeEditModels()
        {
            // Plant
            CreateMap<ProductType.ProductTypeCreateEditModel, CreateUpdateProductTypeDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name));

            CreateMap<ProductType.ProductTypeDestroyEditModel, ProductTypeDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.Name, opt => opt.Ignore());

            CreateMap<ProductType.ProductTypeUpdateEditModel, CreateUpdateProductTypeDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name));
        }

        private void ConfigurePriceListTypeEditModels()
        {
            // Price list
            CreateMap<PriceListType.PriceListTypeCreateEditModel, CreateUpdatePriceListTypeDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dm => dm.Kind, opt => opt.MapFrom(uio => uio.Kind));

            CreateMap<PriceListType.PriceListTypeDestroyEditModel, PriceListTypeDataModel>()
                .ForMember(dm => dm.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dm => dm.Name, opt => opt.Ignore())
                .ForMember(dm => dm.Kind, opt => opt.Ignore());

            CreateMap<PriceListType.PriceListTypeUpdateEditModel, CreateUpdatePriceListTypeDataModel>()
                .ForMember(dm => dm.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dm => dm.Kind, opt => opt.MapFrom(uio => uio.Kind));
        }

        #endregion Configure Edit Models
    }
}