using AutoMapper;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Api.Models.DomainFunctions;
using Genus = PlantData.Web.Blazor.UIModels.ViewModels.Genus;
using Plant = PlantData.Web.Blazor.UIModels.ViewModels.Plant;
using SeedBatch = PlantData.Web.Blazor.UIModels.ViewModels.SeedBatch;
using Site = PlantData.Web.Blazor.UIModels.ViewModels.Site;
using SeedTray = PlantData.Web.Blazor.UIModels.ViewModels.SeedTray;
using ProductType = PlantData.Web.Blazor.UIModels.ViewModels.ProductType;
using SaleEvent = PlantData.Web.Blazor.UIModels.ViewModels.SaleEvent;
using Label = PlantData.Web.Blazor.UIModels.ViewModels.Label;

//using PlantStock = PlantData.Web.Mvc.Models.ViewModels.PlantStock;
//using PriceListType = PlantData.Web.Mvc.Models.ViewModels.PriceListType;
//using ProductPrice = PlantData.Web.Mvc.Models.ViewModels.ProductPrice;
//using SaleEventStock = PlantData.Web.Mvc.Models.ViewModels.SaleEventStock;
//using StocktakeHeader = PlantData.Web.Mvc.Models.ViewModels.StocktakeHeader;
//using Transaction = PlantData.Web.Mvc.Models.ViewModels.Transaction;

namespace PlantData.Web.Blazor.Mappers
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
            ConfigureSiteViewModels();
            ConfigureSeedTrayViewModels();
            ConfigureProductTypeViewModels();
            ConfigureSaleEventViewModels();
            ConfigureLabelViewModels();
            //ConfigurePlantStockViewModels();
            //ConfigureTransactionViewModels();
            //ConfigureSaleEventStockViewModels();
            //ConfigurePriceListTypeViewModels();
            //ConfigureProductPriceViewModels();
            //ConfigureStocktakeHeaderViewModels();
        }

        #region Configure View Models

        private void ConfigureGenusViewModels()
        {
            CreateMap<GenusDataModel, Genus.GenusGridModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dm => dm.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            CreateMap<SpeciesDataModel, Plant.PlantGridModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpecificName)))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dm => dm.CommonName))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dm => dm.GenusName))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dm => dm.GenusId))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dm => dm.Native))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dm => dm.SpecificName));
        }

        private void ConfigureSeedBatchViewModels()
        {
            CreateMap<SeedBatchDataModel, SeedBatch.SeedBatchGridModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dm => dm.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dm => dm.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));
        }

        private void ConfigureSiteViewModels()
        {
            CreateMap<SiteDataModel, Site.SiteGridModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dm => dm.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dm => dm.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dm => dm.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dm => dm.Suburb));
        }

        private void ConfigureSeedTrayViewModels()
        {
            CreateMap<SeedTrayDataModel, SeedTray.SeedTrayGridModel>()
                .ForMember(uio => uio.DateSown, opt => opt.MapFrom(dm => dm.DateSown))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dm => dm.SeedBatchId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.SeedBatchGenusName, dm.SeedBatchSpeciesName)))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dm => dm.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dm => dm.Treatment));
        }

        private void ConfigureProductTypeViewModels()
        {
            CreateMap<ProductTypeDataModel, ProductType.ProductTypeGridModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));
        }

        private void ConfigureSaleEventViewModels()
        {
            CreateMap<SaleEventDataModel, SaleEvent.SaleEventGridModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
                .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
                .ForMember(uio => uio.SaleDate, opt => opt.MapFrom(dm => dm.SaleDate))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dm => dm.Location));
        }

        private void ConfigureLabelViewModels()
        {
            CreateMap<SpeciesDataModel, Label.PlantLabelGridModel>()
               .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.Id))
               .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpecificName)))
               .ForMember(uio => uio.LabelQuantity, opt => opt.MapFrom(dm => 0));
        }

        //private void ConfigurePlantStockViewModels()
        //{
        //    // PlantStockDTO
        //    CreateMap<PlantStockDataModel, PlantStock.PlantStockDeleteViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
        //    // TODO: What about ProductTypeId from dm?

        //    CreateMap<PlantStockDataModel, PlantStock.PlantStockEditViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
        //    // TODO: What about ProductTypeName from dm?

        //    CreateMap<PlantStockDataModel, PlantStock.PlantStockListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
        //    // TODO: What about ProductTypeId from dm?

        //    CreateMap<PlantStockDataModel, PlantStock.PlantStockNewViewModel>()
        //        .ForMember(uio => uio.SpeciesId, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.Ignore())   // TODO: Map product type in plant stock object
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock));
        //    // TODO: What about SpeciesId from dm?
        //    // TODO: What about ProductTypeName from dm?

        //    CreateMap<PlantStockDataModel, PlantStock.PlantStockShowViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId));
        //    // TODO: What about ProductTypeId from dm?
        //}

        //private void ConfigureTransactionViewModels()
        //{
        //    // JournalEntryDTO
        //    CreateMap<JournalEntryDataModel, Transaction.TransactionDeleteViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
        //        .ForMember(uio => uio.EffectiveQuantity, opt => opt.MapFrom(dm => dm.EffectiveQuantity))
        //        .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
        //        .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
        //        .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
        //        .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dm => dm.JournalEntryTypeName));

        //    CreateMap<JournalEntryDataModel, Transaction.TransactionEditViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
        //        .ForMember(uio => uio.EffectiveQuantity, opt => opt.MapFrom(dm => dm.EffectiveQuantity))
        //        .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
        //        .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
        //        .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
        //        .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId));

        //    CreateMap<JournalEntryDataModel, Transaction.TransactionListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
        //        .ForMember(uio => uio.EffectiveQuantity, opt => opt.MapFrom(dm => dm.EffectiveQuantity))
        //        .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
        //        .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dm => dm.JournalEntryTypeName));

        //    CreateMap<JournalEntryDataModel, Transaction.TransactionNewViewModel>()
        //        .ForMember(uio => uio.Notes, opt => opt.MapFrom(dm => dm.Notes))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity))
        //        .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dm => dm.SeedTrayId))
        //        .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dm => dm.TransactionDate))
        //        .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dm => dm.Source))
        //        .ForMember(uio => uio.TransactionTypeId, opt => opt.MapFrom(dm => dm.JournalEntryTypeId));

        //    CreateMap<JournalEntryStockSummaryDataModel, Transaction.TransactionStockSummaryListViewModel>()
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)));

        //    CreateMap<JournalEntryStockSummaryDataModel, Transaction.TransactionStockSummaryDetailsViewModel>()
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.Transactions, opt => opt.MapFrom(dm => dm.JournalEntries));

        //    CreateMap<JournalEntryStockSummaryDataModel, Transaction.TransactionStocktakeListViewModel>()
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.CountedQuantity, opt => opt.MapFrom(dm => dm.QuantityInStock))
        //        .ForMember(uio => uio.Discrepancy, opt => opt.MapFrom(dm => 0))
        //        .ForMember(uio => uio.Reason, opt => opt.MapFrom(dm => string.Empty))
        //        .ForMember(uio => uio.IsStock, opt => opt.MapFrom(dm => true));
        //}

        //private void ConfigureSaleEventStockViewModels()
        //{
        //    CreateMap<SaleEventStockDataModel, SaleEventStock.SaleEventStockListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.SaleEventId, opt => opt.MapFrom(dm => dm.SaleEventId))
        //        .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dm => dm.SpeciesId))
        //        .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dm => SpeciesFunctions.GetBinomial(dm.GenusName, dm.SpeciesName)))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dm => dm.Quantity));

        //}

        //private void ConfigurePriceListTypeViewModels()
        //{
        //    // PriceListType
        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeDeleteViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeEditViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeNewViewModel>()
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeShowViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name));

        //    CreateMap<PriceListTypeDataModel, PriceListType.PriceListTypeDetailsViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Name, opt => opt.MapFrom(dm => dm.Name))
        //        .ForMember(uio => uio.Kind, opt => opt.MapFrom(dm => dm.Kind))
        //        .ForMember(uio => uio.EffectiveDates, opt => opt.MapFrom(dm => dm.ProductPrices.Select(m => m.DateEffective).Distinct().ToList()))
        //        .ForMember(uio => uio.SelectedEffectiveDate, opt => opt.MapFrom(dm => dm.ProductPrices.OrderBy(m => m.DateEffective).Select(m => m.DateEffective).FirstOrDefault()))
        //        .ForMember(uio => uio.ProductPrices, opt => opt.MapFrom(dm => dm.ProductPrices))
        //        ;
        //}

        //private void ConfigureProductPriceViewModels()
        //{
        //    CreateMap<ProductPriceDataModel, ProductPrice.ProductPriceDeleteViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.PriceListTypeId, opt => opt.MapFrom(dm => dm.PriceListTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.PriceListTypeName, opt => opt.MapFrom(dm => dm.PriceListTypeName))
        //        .ForMember(uio => uio.DateEffective, opt => opt.MapFrom(dm => dm.DateEffective))
        //        .ForMember(uio => uio.Price, opt => opt.MapFrom(dm => dm.Price))
        //        .ForMember(uio => uio.BarcodeSKU, opt => opt.MapFrom(dm => dm.BarcodeSKU));

        //    CreateMap<ProductPriceDataModel, ProductPrice.ProductPriceEditViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.PriceListTypeId, opt => opt.MapFrom(dm => dm.PriceListTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.PriceListTypeName, opt => opt.MapFrom(dm => dm.PriceListTypeName))
        //        .ForMember(uio => uio.DateEffective, opt => opt.MapFrom(dm => dm.DateEffective))
        //        .ForMember(uio => uio.Price, opt => opt.MapFrom(dm => dm.Price))
        //        .ForMember(uio => uio.BarcodeSKU, opt => opt.MapFrom(dm => dm.BarcodeSKU));

        //    CreateMap<ProductPriceDataModel, ProductPrice.ProductPriceListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.PriceListTypeId, opt => opt.MapFrom(dm => dm.PriceListTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.PriceListTypeName, opt => opt.MapFrom(dm => dm.PriceListTypeName))
        //        .ForMember(uio => uio.DateEffective, opt => opt.MapFrom(dm => dm.DateEffective))
        //        .ForMember(uio => uio.Price, opt => opt.MapFrom(dm => dm.Price))
        //        .ForMember(uio => uio.BarcodeSKU, opt => opt.MapFrom(dm => dm.BarcodeSKU));

        //    CreateMap<ProductPriceDataModel, ProductPrice.ProductPriceNewViewModel>()
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.PriceListTypeId, opt => opt.MapFrom(dm => dm.PriceListTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.PriceListTypeName, opt => opt.MapFrom(dm => dm.PriceListTypeName))
        //        .ForMember(uio => uio.DateEffective, opt => opt.MapFrom(dm => dm.DateEffective))
        //        .ForMember(uio => uio.Price, opt => opt.MapFrom(dm => dm.Price))
        //        .ForMember(uio => uio.BarcodeSKU, opt => opt.MapFrom(dm => dm.BarcodeSKU));

        //    CreateMap<ProductPriceDataModel, ProductPrice.ProductPriceShowViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.ProductTypeId, opt => opt.MapFrom(dm => dm.ProductTypeId))
        //        .ForMember(uio => uio.PriceListTypeId, opt => opt.MapFrom(dm => dm.PriceListTypeId))
        //        .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dm => dm.ProductTypeName))
        //        .ForMember(uio => uio.PriceListTypeName, opt => opt.MapFrom(dm => dm.PriceListTypeName))
        //        .ForMember(uio => uio.DateEffective, opt => opt.MapFrom(dm => dm.DateEffective))
        //        .ForMember(uio => uio.Price, opt => opt.MapFrom(dm => dm.Price))
        //        .ForMember(uio => uio.BarcodeSKU, opt => opt.MapFrom(dm => dm.BarcodeSKU));
        //}

        //private void ConfigureStocktakeHeaderViewModels()
        //{
        //    // StocktakeHeader
        //    CreateMap<StocktakeDataModel, StocktakeHeader.StocktakeHeaderDeleteViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Reference, opt => opt.MapFrom(dm => dm.Reference))
        //        .ForMember(uio => uio.StocktakeDate, opt => opt.MapFrom(dm => dm.StocktakeDate));

        //    CreateMap<StocktakeDataModel, StocktakeHeader.StocktakeHeaderEditViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Reference, opt => opt.MapFrom(dm => dm.Reference))
        //        .ForMember(uio => uio.StocktakeDate, opt => opt.MapFrom(dm => dm.StocktakeDate));

        //    CreateMap<StocktakeDataModel, StocktakeHeader.StocktakeHeaderListViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Reference, opt => opt.MapFrom(dm => dm.Reference))
        //        .ForMember(uio => uio.StocktakeDate, opt => opt.MapFrom(dm => dm.StocktakeDate));

        //    CreateMap<StocktakeDataModel, StocktakeHeader.StocktakeHeaderNewViewModel>()
        //        .ForMember(uio => uio.Reference, opt => opt.MapFrom(dm => dm.Reference))
        //        .ForMember(uio => uio.StocktakeDate, opt => opt.MapFrom(dm => dm.StocktakeDate));

        //    CreateMap<StocktakeDataModel, StocktakeHeader.StocktakeHeaderShowViewModel>()
        //        .ForMember(uio => uio.Id, opt => opt.MapFrom(dm => dm.Id))
        //        .ForMember(uio => uio.Reference, opt => opt.MapFrom(dm => dm.Reference))
        //        .ForMember(uio => uio.StocktakeDate, opt => opt.MapFrom(dm => dm.StocktakeDate));
        //}

        #endregion Configure View Models
    }
}