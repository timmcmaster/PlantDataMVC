using AutoMapper;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.ViewModels;
using System;

namespace PlantDataMVC.UI.Mappers
{
    /// <summary>
    /// HACK: Temporarily mapping every field explicitly to see what maps through
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DTOToUIMappingProfile : Profile
    {
        public DTOToUIMappingProfile()
        {
            ConfigureDTOToViewModels();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the UI layer view models
        /// </summary>
        private void ConfigureDTOToViewModels()
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
            CreateMap<GenusDTO, GenusDeleteViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDTO, GenusEditViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDTO, GenusListViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDTO, GenusNewViewModel>()
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));

            CreateMap<GenusDTO, GenusShowViewModel>()
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => dto.LatinName));
        }

        private void ConfigurePlantViewModels()
        {
            // SpeciesDTO
            CreateMap<SpeciesDTO, PlantDeleteViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.LatinName, opt => opt.MapFrom(dto => "Hey, fix me!"))        // TODO: map binomial name
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDTO, PlantEditViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDTO, PlantListViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => "Hey, fix me!"))           // TODO: Fix this
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<SpeciesDTO, PlantNewViewModel>()
               .ForMember(uio => uio.CommonName, opt => opt.MapFrom(dto => dto.CommonName))
               .ForMember(uio => uio.Description, opt => opt.MapFrom(dto => dto.Description))
               .ForMember(uio => uio.Genus, opt => opt.MapFrom(dto => "Hey, fix me!"))              // TODO: Fix this
               .ForMember(uio => uio.Native, opt => opt.MapFrom(dto => dto.Native))
               .ForMember(uio => uio.PropagationTime, opt => opt.MapFrom(dto => dto.PropagationTime))
               .ForMember(uio => uio.Species, opt => opt.MapFrom(dto => dto.SpecificName));

            CreateMap<SpeciesDTO, PlantShowViewModel>()
               .ForMember(uio => uio.Binomial, opt => opt.MapFrom(dto => "Hey, fix me!"))           // TODO: Fix this
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
            CreateMap<SeedBatchDTO, PlantSeedDeleteViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDTO, PlantSeedEditViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.SiteId, opt => opt.MapFrom(dto => dto.SiteId))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDTO, PlantSeedListViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => "Hey, fix me!"))          // TODO: Fix this
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));

            CreateMap<SeedBatchDTO, PlantSeedNewViewModel>()
                .ForMember(uio => uio.DateCollected, opt => opt.MapFrom(dto => dto.DateCollected))
                .ForMember(uio => uio.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantSpecies, opt => opt.Ignore())    // don't need to map species up for new seed batch
                .ForMember(uio => uio.Site, opt => opt.Ignore());           // don't need to map site up for new seed batch

            CreateMap<SeedBatchDTO, PlantSeedShowViewModel>()
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
            CreateMap<SiteDTO, SiteDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDTO, SiteEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDTO, SiteListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDTO, SiteNewViewModel>()
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));

            CreateMap<SiteDTO, SiteShowViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Latitude, opt => opt.MapFrom(dto => dto.Latitude))
                .ForMember(uio => uio.Longitude, opt => opt.MapFrom(dto => dto.Longitude))
                .ForMember(uio => uio.SiteName, opt => opt.MapFrom(dto => dto.SiteName))
                .ForMember(uio => uio.Suburb, opt => opt.MapFrom(dto => dto.Suburb));
        }

        private void ConfigurePlantStockEntryViewModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockDTO, PlantStockEntryDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDTO, PlantStockEntryEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductType, opt => opt.Ignore())         // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDTO, PlantStockEntryListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.ProductTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock))
                .ForMember(uio => uio.SpeciesBinomial, opt => opt.MapFrom(dto => "Hey, fix me!"))   // TODO: Fix this
                .ForMember(uio => uio.SpeciesId, opt => opt.MapFrom(dto => dto.SpeciesId));
            // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDTO, PlantStockEntryNewViewModel>()
                .ForMember(uio => uio.PlantSpecies, opt => opt.Ignore())    // don't need to map species up for new stock (TODO: Confirm)
                .ForMember(uio => uio.ProductType, opt => opt.Ignore())   // TODO: Fix this
                .ForMember(uio => uio.QuantityInStock, opt => opt.MapFrom(dto => dto.QuantityInStock));
                // TODO: What about SpeciesId from dto?
                // TODO: What about ProductTypeId from dto?

            CreateMap<PlantStockDTO, PlantStockEntryShowViewModel>()
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
            CreateMap<JournalEntryDTO, PlantStockTransactionDeleteViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"));   // TODO: Fix this

            CreateMap<JournalEntryDTO, PlantStockTransactionEditViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionType, opt => opt.Ignore());   // TODO: Fix this

            CreateMap<JournalEntryDTO, PlantStockTransactionListViewModel>()
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionTypeName, opt => opt.MapFrom(dto => "Hey, fix me!"));   // TODO: Fix this

            CreateMap<JournalEntryDTO, PlantStockTransactionNewViewModel>()
                .ForMember(uio => uio.Notes, opt => opt.MapFrom(dto => dto.Notes))
                .ForMember(uio => uio.PlantStockEntryId, opt => opt.MapFrom(dto => dto.PlantStockId))
                .ForMember(uio => uio.Quantity, opt => opt.MapFrom(dto => dto.Quantity))
                .ForMember(uio => uio.SeedTrayId, opt => opt.MapFrom(dto => dto.SeedTrayId))
                .ForMember(uio => uio.TransactionDate, opt => opt.MapFrom(dto => dto.TransactionDate))
                .ForMember(uio => uio.TransactionSource, opt => opt.MapFrom(dto => dto.Source))
                .ForMember(uio => uio.TransactionType, opt => opt.Ignore());   // TODO: Fix this

            CreateMap<JournalEntryDTO, PlantStockTransactionShowViewModel>()
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
            CreateMap<SeedTrayDTO, TrayDeleteViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDTO, TrayEditViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDTO, TrayListViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDTO, TrayNewViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.SeedBatch, opt => opt.Ignore())   // // don't need to map seed batch up for new seed tray (TODO: Check this)
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));

            CreateMap<SeedTrayDTO, TrayShowViewModel>()
                .ForMember(uio => uio.DatePlanted, opt => opt.MapFrom(dto => dto.DatePlanted))
                .ForMember(uio => uio.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(uio => uio.SeedBatchId, opt => opt.MapFrom(dto => dto.SeedBatchId))
                .ForMember(uio => uio.ThrownOut, opt => opt.MapFrom(dto => dto.ThrownOut))
                .ForMember(uio => uio.Treatment, opt => opt.MapFrom(dto => dto.Treatment));
        }

        #endregion Configure View Models
    }
}