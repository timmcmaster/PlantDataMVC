using AutoMapper;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.DomainFunctions;
using PlantDataMVC.Repository.Models;
using Genus = PlantDataMVC.Web.Models.ViewModels.Genus;
using Plant = PlantDataMVC.Web.Models.ViewModels.Plant;
using PlantStock = PlantDataMVC.Web.Models.ViewModels.PlantStock;
using PriceListType = PlantDataMVC.Web.Models.ViewModels.PriceListType;
using ProductType = PlantDataMVC.Web.Models.ViewModels.ProductType;
using SaleEvent = PlantDataMVC.Web.Models.ViewModels.SaleEvent;
using SeedBatch = PlantDataMVC.Web.Models.ViewModels.SeedBatch;
using SeedTray = PlantDataMVC.Web.Models.ViewModels.SeedTray;
using Site = PlantDataMVC.Web.Models.ViewModels.Site;
using Transaction = PlantDataMVC.Web.Models.ViewModels.Transaction;

namespace PlantDataMVC.Web.Mappers
{
    /// <inheritdoc />
    /// <summary>
    /// HACK: Temporarily mapping every field explicitly to see what maps through
    /// </summary>
    /// <seealso cref="T:AutoMapper.Profile" />
    public class DataModelToUIMappingProfile : Profile
    {
        public DataModelToUIMappingProfile()
        {
            ConfigureDataModelToViewModels();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the UI layer view models
        /// </summary>
        private void ConfigureDataModelToViewModels()
        {
            // Maps from Domain to UI view models
            ConfigureGenusViewModels();
            ConfigurePlantViewModels();
            ConfigureSeedBatchViewModels();
            ConfigureSeedTrayViewModels();
            ConfigurePlantStockViewModels();
            ConfigureTransactionViewModels();
            ConfigureSiteViewModels();
            ConfigureSaleEventViewModels();
            ConfigureProductTypeViewModels();
            ConfigurePriceListTypeViewModels();
        }

        #region Configure View Models

        private void ConfigureGenusViewModels()
        {
            // Genus
            CreateMap<GenusDataModel, Genus.GenusDeleteViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));

            CreateMap<GenusDataModel, Genus.GenusEditViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));

            CreateMap<GenusDataModel, Genus.GenusListViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));


            CreateMap<GenusDataModel, Genus.GenusNewViewModel>()
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));

            CreateMap<GenusDataModel, Genus.GenusShowViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            // SpeciesDTO
            CreateMap<SpeciesDataModel, Plant.PlantDeleteViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dm => dm.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dm => dm.GenusName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpecificName)))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dm => dm.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantEditViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dm => dm.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dm => dm.GenusId))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dm => dm.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantListViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpecificName)))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native));

            CreateMap<SpeciesDataModel, Plant.PlantNewViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dm => dm.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dm => dm.GenusId))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dm => dm.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantShowViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpecificName)))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dm => dm.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dm => dm.GenusName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dm => dm.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dm => dm.SpecificName));
        }

        private void ConfigureSeedBatchViewModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchDeleteViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dm => dm.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchEditViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dm => dm.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchListViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchNewViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dm => dm.SiteId));

            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchShowViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dm => dm.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));
        }

        private void ConfigureSiteViewModels()
        {
            // Site
            CreateMap<SiteDataModel, Site.SiteDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));

            CreateMap<SiteDataModel, Site.SiteEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));

            CreateMap<SiteDataModel, Site.SiteListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));

            CreateMap<SiteDataModel, Site.SiteNewViewModel>()
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));

            CreateMap<SiteDataModel, Site.SiteShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));
        }

        private void ConfigurePlantStockViewModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockDataModel, PlantStock.PlantStockDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
                // TODO: What about ProductTypeId from dm?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
                // TODO: What about ProductTypeName from dm?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
            // TODO: What about ProductTypeId from dm?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockNewViewModel>()
                .ForMember(uio => uio.SpeciesId, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
                .ForMember(uio => uio.ProductTypeId, opt => opt.Ignore())   // TODO: Map product type in plant stock object
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock));
                // TODO: What about SpeciesId from dm?
                // TODO: What about ProductTypeName from dm?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
            // TODO: What about ProductTypeId from dm?

            // PlantStockDetailsViewModel
            CreateMap<PlantStockDataModel, PlantStock.PlantStockDetailsViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
            // TODO: What about ProductTypeId from dm?

        }

        private void ConfigureTransactionViewModels()
        {
            // JournalEntryDTO
            CreateMap<JournalEntryDataModel, Transaction.TransactionDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dm => dm.JournalEntryTypeName));

            CreateMap<JournalEntryDataModel, Transaction.TransactionEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId));

            CreateMap<JournalEntryDataModel, Transaction.TransactionListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dm => dm.JournalEntryTypeName));

            CreateMap<JournalEntryDataModel, Transaction.TransactionNewViewModel>()
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId));

            CreateMap<JournalEntryStockSummaryDataModel, Transaction.TransactionStockSummaryListViewModel>()
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));
        }

        private void ConfigureSeedTrayViewModels()
        {
            // SeedTray
            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayDeleteViewModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.SeedBatchGenusName, dm.SeedBatchSpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));

            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayEditViewModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SeedBatchSpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.SeedBatchGenusName, dm.SeedBatchSpeciesName)))
                .ForMember(uio => uio.SeedBatchLocation, opt => opt.MapFrom(dm => dm.SeedBatchLocation))
                .ForMember(uio => uio.SeedBatchDateCollected, opt => opt.MapFrom(dm => dm.SeedBatchDateCollected))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));

            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayListViewModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.SeedBatchGenusName, dm.SeedBatchSpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));

            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayNewViewModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.SeedBatchId, opt => opt.Ignore())  // don't need to map seed batch up for new seed tray (TODO: Check this)
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));

            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayShowViewModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SeedBatchSpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.SeedBatchGenusName, dm.SeedBatchSpeciesName)))
                .ForMember(uio => uio.SeedBatchLocation, opt => opt.MapFrom(dm => dm.SeedBatchLocation))
                .ForMember(uio => uio.SeedBatchDateCollected, opt => opt.MapFrom(dm => dm.SeedBatchDateCollected))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));
        }

        private void ConfigureSaleEventViewModels()
        {
            // SaleEvent
            CreateMap<SaleEventDataModel, SaleEvent.SaleEventDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventNewViewModel>()
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));
        }

        private void ConfigureProductTypeViewModels()
        {
            // ProductType
            CreateMap<ProductTypeDataModel, ProductType.ProductTypeDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<ProductTypeDataModel, ProductType.ProductTypeEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<ProductTypeDataModel, ProductType.ProductTypeListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<ProductTypeDataModel, ProductType.ProductTypeNewViewModel>()
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<ProductTypeDataModel, ProductType.ProductTypeShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));
        }

        private void ConfigurePriceListTypeViewModels()
        {
            // PriceListType
            CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeNewViewModel>()
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

            CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));
        }
        #endregion Configure View Models
    }
}