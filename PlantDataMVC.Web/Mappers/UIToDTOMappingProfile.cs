﻿using AutoMapper;
using PlantDataMVC.UICore.Models.EditModels.SeedBatch;
using PlantDataMVC.UICore.Models.EditModels.SeedTray;
using System;
using Genus = PlantDataMVC.UICore.Models.EditModels.Genus;
using Plant = PlantDataMVC.UICore.Models.EditModels.Plant;
using PlantStock = PlantDataMVC.UICore.Models.EditModels.PlantStock;
using Site = PlantDataMVC.UICore.Models.EditModels.Site;
using Transaction = PlantDataMVC.UICore.Models.EditModels.Transaction;
using SaleEvent = PlantDataMVC.UICore.Models.EditModels.SaleEvent;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.UICore.Mappers
{
    public class UiToDtoMappingProfile : Profile
    {
        public UiToDtoMappingProfile()
        {
            ConfigureEditModelsToDto();
        }

        /// <summary>
        /// Configure the mappings from the UI layer edit models to the App/Business Layer objects
        /// </summary>
        private void ConfigureEditModelsToDto()
        {
            ConfigureGenusEditModels();
            ConfigurePlantEditModels();
            ConfigureSeedBatchEditModels();
            ConfigureSeedTrayEditModels();
            ConfigurePlantStockEditModels();
            ConfigureTransactionEditModels();
            ConfigureSiteEditModels();
            ConfigureSaleEventEditModels();
            // Maps from UI edit models to domain
        }

        #region Configure Edit Models

        private void ConfigureGenusEditModels()
        {
            // Plant
            CreateMap<Genus.GenusCreateEditModel, CreateUpdateGenusDataModel>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName));

            CreateMap<Genus.GenusDestroyEditModel, GenusDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.LatinName, opt => opt.Ignore())
                .ForMember(dto => dto.Species, opt => opt.Ignore());

            CreateMap<Genus.GenusUpdateEditModel, CreateUpdateGenusDataModel>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName));

            //CreateMap<GenusUpdateEditModel, GenusDto>()
            //    .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
            //    .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
            //    .ForMember(dto => dto.Species, opt => opt.Ignore());     // TODO: check about mapping back collection
        }

        private void ConfigurePlantEditModels()
        {
            // Plant
            CreateMap<Plant.PlantCreateEditModel, SpeciesDataModel>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(uio => uio.GenusId))
                .ForMember(dto => dto.GenusName, opt => opt.Ignore())
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));

            CreateMap<Plant.PlantDestroyEditModel, SpeciesDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.GenusId, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore())
                .ForMember(dto => dto.SpecificName, opt => opt.Ignore())
                .ForMember(dto => dto.CommonName, opt => opt.Ignore())
                .ForMember(dto => dto.Description, opt => opt.Ignore())
                .ForMember(dto => dto.PropagationTime, opt => opt.Ignore())
                .ForMember(dto => dto.Native, opt => opt.Ignore())
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore());

            CreateMap<Plant.PlantUpdateEditModel, SpeciesDataModel>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.MapFrom(uio => uio.GenusId))
                .ForMember(dto => dto.GenusName, opt => opt.Ignore())
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));
        }

        private void ConfigureSeedBatchEditModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatchCreateEditModel, SeedBatchDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                          // Id on create will come back from DB
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId))
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.SiteName, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore());

            CreateMap<SeedBatchDestroyEditModel, SeedBatchDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.SpeciesId, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore())
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.DateCollected, opt => opt.Ignore())
                .ForMember(dto => dto.Location, opt => opt.Ignore())
                .ForMember(dto => dto.Notes, opt => opt.Ignore())
                .ForMember(dto => dto.SiteId, opt => opt.Ignore())
                .ForMember(dto => dto.SiteName, opt => opt.Ignore())
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore());

        CreateMap<SeedBatchUpdateEditModel, SeedBatchDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId))
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.SiteName, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore());
        }

        private void ConfigureSiteEditModels()
        {
            // SiteDTO
            CreateMap<Site.SiteCreateEditModel, SiteDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore()) // Id on create will come back from DB
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore()) // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));


            CreateMap<Site.SiteDestroyEditModel, SiteDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.SiteName, opt => opt.Ignore())
                .ForMember(dto => dto.Suburb, opt => opt.Ignore())
                .ForMember(dto => dto.Latitude, opt => opt.Ignore())
                .ForMember(dto => dto.Longitude, opt => opt.Ignore())
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore());

            CreateMap<Site.SiteUpdateEditModel, SiteDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                     // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));
        }

        private void ConfigurePlantStockEditModels()
        {
            // PlantStockDTO
            CreateMap<PlantStock.PlantStockCreateEditModel, PlantStockDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId))
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.ProductTypeName, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore());
            ;

            CreateMap<PlantStock.PlantStockDestroyEditModel, PlantStockDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.SpeciesId, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore())
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.ProductTypeId, opt => opt.Ignore())
                .ForMember(dto => dto.ProductTypeName, opt => opt.Ignore())
                .ForMember(dto => dto.QuantityInStock, opt => opt.Ignore())
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore());

        CreateMap<PlantStock.PlantStockUpdateEditModel, PlantStockDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId))
                .ForMember(dto => dto.SpeciesName, opt => opt.Ignore())
                .ForMember(dto => dto.ProductTypeName, opt => opt.Ignore())
                .ForMember(dto => dto.GenusName, opt => opt.Ignore());
        }

        private void ConfigureTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<Transaction.TransactionCreateEditModel, JournalEntryDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                 // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate))
                .ForMember(dto => dto.JournalEntryTypeName, opt => opt.Ignore());

            CreateMap<Transaction.TransactionDestroyEditModel, JournalEntryDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.PlantStockId, opt => opt.Ignore())
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.Ignore())
                .ForMember(dto => dto.JournalEntryTypeName, opt => opt.Ignore())
                .ForMember(dto => dto.TransactionDate, opt => opt.Ignore())
                .ForMember(dto => dto.Quantity, opt => opt.Ignore())
                .ForMember(dto => dto.SeedTrayId, opt => opt.Ignore())
                .ForMember(dto => dto.Source, opt => opt.Ignore())
                .ForMember(dto => dto.Notes, opt => opt.Ignore());

        CreateMap<Transaction.TransactionUpdateEditModel, JournalEntryDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate))
                .ForMember(dto => dto.JournalEntryTypeName, opt => opt.Ignore());
        }

        private void ConfigureSeedTrayEditModels()
        {
            // SeedTray
            CreateMap<SeedTrayCreateEditModel, SeedTrayDataModel>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));

            CreateMap<SeedTrayDestroyEditModel, SeedTrayDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.SeedBatchId, opt => opt.Ignore())
                .ForMember(dto => dto.DatePlanted, opt => opt.Ignore())
                .ForMember(dto => dto.Treatment, opt => opt.Ignore())
                .ForMember(dto => dto.ThrownOut, opt => opt.Ignore())
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore());

        CreateMap<SeedTrayUpdateEditModel, SeedTrayDataModel>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));
        }

        private void ConfigureSaleEventEditModels()
        {
            // SaleEventDTO
            CreateMap<SaleEvent.SaleEventCreateEditModel, SaleEventDataModel>()
                .ForMember(dto => dto.Id, opt => opt.Ignore()) // Id on create will come back from DB
                .ForMember(dto => dto.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dto => dto.SaleDate, opt => opt.MapFrom(uio => uio.SaleDate))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location));


            CreateMap<SaleEvent.SaleEventDestroyEditModel, SaleEventDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Name, opt => opt.Ignore())
                .ForMember(dto => dto.SaleDate, opt => opt.Ignore())
                .ForMember(dto => dto.Location, opt => opt.Ignore());

            CreateMap<SaleEvent.SaleEventUpdateEditModel, SaleEventDataModel>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(uio => uio.Name))
                .ForMember(dto => dto.SaleDate, opt => opt.MapFrom(uio => uio.SaleDate))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location));
        }

        #endregion Configure Edit Models
    }
}