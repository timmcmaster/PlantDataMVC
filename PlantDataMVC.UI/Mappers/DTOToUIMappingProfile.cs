using AutoMapper;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Mappers
{
    /// <summary>
    /// HACK: Temporarily mapping every field explicitly to see what maps through
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
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
            ConfigurePlantSeedViewModels();
            ConfigurePlantSeedTrayViewModels();
            ConfigurePlantStockEntryViewModels();
            ConfigurePlantStockTransactionViewModels();
            ConfigurePlantSeedSiteViewModels();
        }

        #region Configure View Models

        private void ConfigureGenusViewModels()
        {
            // Genus
            CreateMap<GenusDto, GenusDeleteViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, GenusEditViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusInListDto, GenusListViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, GenusNewViewModel>()
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDto, GenusShowViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            // SpeciesDTO
            CreateMap<SpeciesDto, PlantDeleteViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => "Hey, fix me!"))        // TODO: map binomial name
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDto, PlantEditViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesInListDto, PlantListViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => "(Fix me!) " + dto.SpecificName))           // TODO: Fix this
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<SpeciesDto, PlantNewViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDto, PlantShowViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => "(Fix me!) " + dto.SpecificName))           // TODO: Fix this
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));
        }

        private void ConfigurePlantSeedViewModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatchDto, PlantSeedDeleteViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDto, PlantSeedEditViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDto, PlantSeedListViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDto, PlantSeedNewViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantSpecies, opt => opt.Ignore())    // don't need to map species up for new seed batch
                .ForMember(uio => uio.Site, opt => opt.Ignore());           // don't need to map site up for new seed batch

            CreateMap<SeedBatchDto, PlantSeedShowViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
        }

        private void ConfigurePlantSeedSiteViewModels()
        {
            // PlantSeedSite
            CreateMap<SiteDto, SiteDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, SiteEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, SiteListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, SiteNewViewModel>()
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDto, SiteShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));
        }

        private void ConfigurePlantStockEntryViewModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockDto, PlantStockEntryDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStockEntryEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductType, opt => opt.Ignore())         // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStockEntryListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStockEntryNewViewModel>()
                .ForMember(uio => uio.PlantSpecies, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
                .ForMember(uio => uio.ProductType, opt => opt.Ignore())   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock));
                // TODO: What about SpeciesId from dto?
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDto, PlantStockEntryShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?
        }

        private void ConfigurePlantStockTransactionViewModels()
        {
            // JournalEntryDTO
            CreateMap<JournalEntryDto, PlantStockTransactionDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"));   // TODO: Fix this

            CreateMap<JournalEntryDto, PlantStockTransactionEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionType, opt => opt.Ignore());   // TODO: Fix this

            CreateMap<JournalEntryDto, PlantStockTransactionListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"));   // TODO: Fix this

            CreateMap<JournalEntryDto, PlantStockTransactionNewViewModel>()
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionType, opt => opt.Ignore());   // TODO: Fix this

            CreateMap<JournalEntryDto, PlantStockTransactionShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"));   // TODO: Fix this
        }

        private void ConfigurePlantSeedTrayViewModels()
        {
            // PlantSeedTray
            CreateMap<SeedTrayDto, TrayDeleteViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, TrayEditViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, TrayListViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, TrayNewViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.SeedBatch, opt => opt.Ignore())   // // don't need to map seed batch up for new seed tray (TODO: Check this)
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDto, TrayShowViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));
        }

        #endregion Configure View Models
    }
}