﻿using AutoMapper;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Mappers
{
    public class UIToDTOMappingProfile : Profile
    {
        public UIToDTOMappingProfile()
        {
            ConfigureEditModelsToDTO();
        }

        /// <summary>
        /// Configure the mappings from the UI layer edit models to the App/Business Layer objects
        /// </summary>
        private void ConfigureEditModelsToDTO()
        {
            ConfigureGenusEditModels();
            ConfigurePlantEditModels();
            ConfigurePlantSeedEditModels();
            ConfigurePlantSeedTrayEditModels();
            ConfigurePlantStockEntryEditModels();
            ConfigurePlantStockTransactionEditModels();
            ConfigurePlantSeedSiteEditModels();
            // Maps from UI edit models to domain
        }

        #region Configure Edit Models

        private void ConfigureGenusEditModels()
        {
            // Plant
            CreateMap<GenusCreateEditModel, GenusDTO>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
                .ForMember(dto => dto.Species, opt => opt.Ignore())     // TODO: check about mapping back collection
                .ForMember(dto => dto.Id, opt => opt.Ignore());         // Id on create will come back from DB

            CreateMap<GenusDestroyEditModel, GenusDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<GenusUpdateEditModel, GenusDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
                .ForMember(dto => dto.Species, opt => opt.Ignore());     // TODO: check about mapping back collection
        }

        private void ConfigurePlantEditModels()
        {
            // Plant
            CreateMap<PlantCreateEditModel, SpeciesDTO>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.Ignore())                             // TODO: handle creation without GenusID  
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));

            CreateMap<PlantDestroyEditModel, SpeciesDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantUpdateEditModel, SpeciesDTO>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.Ignore())                             // TODO: fix GenusID in UIO  
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));
        }

        private void ConfigurePlantSeedEditModels()
        {
            // SeedBatchDTO
            CreateMap<PlantSeedCreateEditModel, SeedBatchDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                          // Id on create will come back from DB
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantSeedDestroyEditModel, SeedBatchDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantSeedUpdateEditModel, SeedBatchDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigurePlantSeedSiteEditModels()
        {
            // SiteDTO
            CreateMap<SiteCreateEditModel, SiteDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())          // Id on create will come back from DB
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));

            CreateMap<SiteDestroyEditModel, SiteDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SiteUpdateEditModel, SiteDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                     // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));
        }

        private void ConfigurePlantStockEntryEditModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockEntryCreateEditModel, PlantStockDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductType.Id))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantStockEntryDestroyEditModel, PlantStockDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockEntryUpdateEditModel, PlantStockDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductType.Id))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<PlantStockTransactionCreateEditModel, JournalEntryDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                 // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockEntryId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));

            CreateMap<PlantStockTransactionDestroyEditModel, JournalEntryDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockTransactionUpdateEditModel, JournalEntryDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockEntryId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));
        }

        private void ConfigurePlantSeedTrayEditModels()
        {
            // PlantSeedTray
            CreateMap<TrayCreateEditModel, SeedTrayDTO>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));

            CreateMap<TrayDestroyEditModel, SeedTrayDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<TrayUpdateEditModel, SeedTrayDTO>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));
        }

        #endregion Configure Edit Models
    }
}