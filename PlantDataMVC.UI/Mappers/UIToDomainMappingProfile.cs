using AutoMapper;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;
using PlantDataMVC.UI.Models;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.UI.Mappers
{
    public class UIToDomainMappingProfile : Profile
    {
        public UIToDomainMappingProfile()
        {
            ConfigureEditModelsToDomain();
        }

        /// <summary>
        /// Configure the mappings from the UI layer edit models to the App/Business Layer objects
        /// </summary>
        private void ConfigureEditModelsToDomain()
        {
            ConfigurePlantEditModels();
            ConfigurePlantSeedEditModels();
            ConfigurePlantSeedTrayEditModels();
            ConfigurePlantStockEntryEditModels();
            ConfigurePlantStockTransactionEditModels();
            ConfigurePlantSeedSiteEditModels();
            // Maps from UI edit models to domain
        }

        #region Configure Edit Models

        private void ConfigurePlantEditModels()
        {
            // Plant
            CreateMap<PlantCreateEditModel, Plant>()
                .ForMember(bo => bo.GenusLatinName, opt => opt.MapFrom<String>(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(uio => uio.Species.Trim()));

            CreateMap<PlantDestroyEditModel, Plant>();

            CreateMap<PlantUpdateEditModel, Plant>()
                .ForMember(bo => bo.GenusLatinName, opt => opt.MapFrom<String>(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(uio => uio.Species.Trim()));

        }

        private void ConfigurePlantSeedEditModels()
        {
            // PlantSeed
            CreateMap<PlantSeedCreateEditModel, PlantSeed>();
            CreateMap<PlantSeedDestroyEditModel, PlantSeed>();
            CreateMap<PlantSeedUpdateEditModel, PlantSeed>();

        }

        private void ConfigurePlantSeedSiteEditModels()
        {
            // PlantSeedSite
            CreateMap<SiteCreateEditModel, PlantSeedSite>();
            CreateMap<SiteDestroyEditModel, PlantSeedSite>();
            CreateMap<SiteUpdateEditModel, PlantSeedSite>();

        }

        private void ConfigurePlantStockEntryEditModels()
        {
            // PlantStockEntry
            CreateMap<PlantStockEntryCreateEditModel, PlantStockEntry>();
                //.ForMember(bo => bo.ProductType,
                //            opt => opt.MapFrom<PlantProductType>(
                //                uio => _serviceLayer.GetDataService<PlantProductType>().View(new ViewRequest<PlantProductType>(uio.ProductTypeId)).Item));

            CreateMap<PlantStockEntryDestroyEditModel, PlantStockEntry>();
            CreateMap<PlantStockEntryUpdateEditModel, PlantStockEntry>();
                //.ForMember(bo => bo.ProductType,
                //            opt => opt.MapFrom<PlantProductType>(
                //                uio => _serviceLayer.GetDataService<PlantProductType>().View(new ViewRequest<PlantProductType>(uio.ProductTypeId)).Item));

        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // PlantStockTransaction
            CreateMap<PlantStockTransactionCreateEditModel, PlantStockTransaction>();
                //.ForMember(bo => bo.TransactionType,
                //            opt => opt.MapFrom<PlantStockTransactionType>(
                //                uio => _serviceLayer.GetDataService<PlantStockTransactionType>().View(new ViewRequest<PlantStockTransactionType>(uio.TransactionTypeId)).Item));

            CreateMap<PlantStockTransactionDestroyEditModel, PlantStockTransaction>();
            CreateMap<PlantStockTransactionUpdateEditModel, PlantStockTransaction>();
                //.ForMember(bo => bo.TransactionType,
                //            opt => opt.MapFrom<PlantStockTransactionType>(
                //                uio => _serviceLayer.GetDataService<PlantStockTransactionType>().View(new ViewRequest<PlantStockTransactionType>(uio.TransactionTypeId)).Item));

        }

        private void ConfigurePlantSeedTrayEditModels()
        {
            // PlantSeedTray
            CreateMap<TrayCreateEditModel, PlantSeedTray>();
            CreateMap<TrayDestroyEditModel, PlantSeedTray>();
            CreateMap<TrayUpdateEditModel, PlantSeedTray>();
        }

        #endregion Configure Edit Models
    }
}