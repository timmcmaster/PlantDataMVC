using AutoMapper;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.ViewModels.SeedBatch;
using PlantDataMVC.UI.Models.ViewModels.SeedTray;
using Genus = PlantDataMVC.UI.Models.ViewModels.Genus;
using Plant = PlantDataMVC.UI.Models.ViewModels.Plant;
using PlantStock = PlantDataMVC.UI.Models.ViewModels.PlantStock;
using Site = PlantDataMVC.UI.Models.ViewModels.Site;
using Transaction = PlantDataMVC.UI.Models.ViewModels.Transaction;

namespace PlantDataMVC.UI.Mappers
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
        }

        #region Configure View Models

        private void ConfigureGenusViewModels()
        {
            // Genus
            CreateMap<GenusDto, Genus.GenusDeleteViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, Genus.GenusEditViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, Genus.GenusListViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));


            CreateMap<GenusDto, Genus.GenusNewViewModel>()
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, Genus.GenusShowViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            // SpeciesDTO
            CreateMap<SpeciesDto, Plant.PlantDeleteViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => dto.GenusName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.Binomial))        
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDto, Plant.PlantEditViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dto => dto.GenusId))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDto, Plant.PlantListViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => dto.Binomial))
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<SpeciesDto, Plant.PlantNewViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.GenusId, opt => opt.MapFrom(dto => dto.GenusId))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDto, Plant.PlantShowViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => dto.Binomial))
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
            CreateMap<SeedBatchDto, SeedBatchDeleteViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial));

            CreateMap<SeedBatchDto, SeedBatchEditViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial));

            CreateMap<SeedBatchDto, SeedBatchListViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial));

            CreateMap<SeedBatchDto, SeedBatchNewViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId));

            CreateMap<SeedBatchDto, SeedBatchShowViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial));
        }

        private void ConfigureSiteViewModels()
        {
            // Site
            CreateMap<SiteDto, Site.SiteDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, Site.SiteEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, Site.SiteListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, Site.SiteNewViewModel>()
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, Site.SiteShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));
        }

        private void ConfigurePlantStockViewModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockDto, PlantStock.PlantStockDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStock.PlantStockEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeId, opt => opt.Ignore())         // TODO: Map product type in plant stock object
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStock.PlantStockListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStock.PlantStockNewViewModel>()
                .ForMember(uio => uio.SpeciesId, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
                .ForMember(uio => uio.ProductTypeId, opt => opt.Ignore())   // TODO: Map product type in plant stock object
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock));
                // TODO: What about SpeciesId from dto?
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStock.PlantStockShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            // PlantStockDetailsViewModel
            CreateMap<PlantStockDto, PlantStock.PlantStockDetailsViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => dto.ProductTypeName))
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => dto.SpeciesBinomial))
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId))
                .ForMember(uio => uio.Transactions, opt => opt.MapFrom(dto => dto.JournalEntries))
                ;

        }

        private void ConfigureTransactionViewModels()
        {
            // JournalEntryDTO
            CreateMap<JournalEntryDto, Transaction.TransactionDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => dto.JournalEntryTypeName));

            CreateMap<JournalEntryDto, Transaction.TransactionEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.Ignore());   // TODO: Map transaction type in transaction object

            CreateMap<JournalEntryDto, Transaction.TransactionListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => dto.JournalEntryTypeName));

            CreateMap<JournalEntryDto, Transaction.TransactionNewViewModel>()
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeId, opt => opt.Ignore());   // TODO: Map transaction type in transaction object
        }

        private void ConfigureSeedTrayViewModels()
        {
            // SeedTray
            CreateMap<SeedTrayDto, SeedTrayDeleteViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, SeedTrayEditViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, SeedTrayListViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, SeedTrayNewViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.SeedBatchId, opt => opt.Ignore())   // // don't need to map seed batch up for new seed tray (TODO: Check this)
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, SeedTrayShowViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));
        }

        #endregion Configure View Models
    }
}