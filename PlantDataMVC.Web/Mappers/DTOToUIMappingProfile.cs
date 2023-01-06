using AutoMapper;
using PlantDataMVC.UICore.Models.ViewModels.SeedBatch;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;
using System;
using Genus = PlantDataMVC.UICore.Models.ViewModels.Genus;
using Plant = PlantDataMVC.UICore.Models.ViewModels.Plant;
using PlantStock = PlantDataMVC.UICore.Models.ViewModels.PlantStock;
using Site = PlantDataMVC.UICore.Models.ViewModels.Site;
using Transaction = PlantDataMVC.UICore.Models.ViewModels.Transaction;
using SaleEvent = PlantDataMVC.UICore.Models.ViewModels.SaleEvent;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.DomainFunctions;

namespace PlantDataMVC.UICore.Mappers
{
    /// <inheritdoc />
    /// <summary>
    /// HACK: Temporarily mapping every field explicitly to see what maps through
    /// </summary>
    /// <seealso cref="T:AutoMapper.Profile" />
    public class DtoToUiMappingProfile : Profile
    {
        public DtoToUiMappingProfile()
        {
            ConfigureDtoToViewModels();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the UI layer view models
        /// </summary>
        private void ConfigureDtoToViewModels()
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
        }

        #region Configure View Models

        private void ConfigureGenusViewModels()
        {
            // Genus
            CreateMap<GenusDataModel, Genus.GenusDeleteViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDataModel, Genus.GenusEditViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDataModel, Genus.GenusListViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));


            CreateMap<GenusDataModel, Genus.GenusNewViewModel>()
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDataModel, Genus.GenusShowViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            // SpeciesDTO
            CreateMap<SpeciesDataModel, Plant.PlantDeleteViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => dto.GenusName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpecificName)))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantEditViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dto => dto.GenusId))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantListViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpecificName)))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<SpeciesDataModel, Plant.PlantNewViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dto => dto.GenusId))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDataModel, Plant.PlantShowViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpecificName)))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => dto.GenusName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));
        }

        private void ConfigureSeedBatchViewModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatchDataModel, SeedBatchDeleteViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatchEditViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatchListViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)));

            CreateMap<SeedBatchDataModel, SeedBatchNewViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId));

            CreateMap<SeedBatchDataModel, SeedBatchShowViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)));
        }

        private void ConfigureSiteViewModels()
        {
            // Site
            CreateMap<SiteDataModel, Site.SiteDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDataModel, Site.SiteEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDataModel, Site.SiteListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDataModel, Site.SiteNewViewModel>()
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDataModel, Site.SiteShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));
        }

        private void ConfigurePlantStockViewModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockDataModel, PlantStock.PlantStockDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dto => dto.ProductTypeId))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeName from dto?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockNewViewModel>()
                .ForMember(uio => uio.SpeciesId, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
                .ForMember(uio => uio.ProductTypeId, opt => opt.Ignore())   // TODO: Map product type in plant stock object
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock));
                // TODO: What about SpeciesId from dto?
                // TODO: What about ProductTypeName from dto?

            CreateMap<PlantStockDataModel, PlantStock.PlantStockShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            // PlantStockDetailsViewModel
            CreateMap<PlantStockDataModel, PlantStock.PlantStockDetailsViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.Transactions, opt => opt.MapFrom(dto => dto.JournalEntries));
            // TODO: What about ProductTypeId from dto?

        }

        private void ConfigureTransactionViewModels()
        {
            // JournalEntryDTO
            CreateMap<JournalEntryDataModel, Transaction.TransactionDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => dto.JournalEntryTypeName));

            CreateMap<JournalEntryDataModel, Transaction.TransactionEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dto => dto.JournalEntryTypeId));

            CreateMap<JournalEntryDataModel, Transaction.TransactionListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => dto.JournalEntryTypeName));

            CreateMap<JournalEntryDataModel, Transaction.TransactionNewViewModel>()
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dto => dto.JournalEntryTypeId));
        }

        private void ConfigureSeedTrayViewModels()
        {
            // SeedTray
            CreateMap<SeedTrayDataModel, SeedTrayDeleteViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDataModel, SeedTrayEditViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                //.ForMember(uio => uio.SeedBatchSpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                //.ForMember(uio => uio.SeedBatchLocation, opt => opt.MapFrom(dto => dto.))
                //.ForMember(uio => uio.SeedBatchDateCollected, opt => opt.MapFrom(dto => dto.))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDataModel, SeedTrayListViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDataModel, SeedTrayNewViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.SeedBatchId, opt => opt.Ignore())  // don't need to map seed batch up for new seed tray (TODO: Check this)
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDataModel, SeedTrayShowViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => SpeciesFunctions.GetBinomial(dto.GenusName, dto.SpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));
        }

        private void ConfigureSaleEventViewModels()
        {
            // SaleEvent
            CreateMap<SaleEventDataModel, SaleEvent.SaleEventDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dto => dto.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dto => dto.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dto => dto.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventNewViewModel>()
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dto => dto.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location));

            CreateMap<SaleEventDataModel, SaleEvent.SaleEventShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dto => dto.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location));
        }

        #endregion Configure View Models
    }
}