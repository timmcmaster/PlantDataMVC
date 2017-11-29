using AutoMapper;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;
using PlantDataMVC.UI.Models;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.UI.Mappers
{
    public class DomainToUIMappingProfile : Profile
    {
        public DomainToUIMappingProfile()
        {
            ConfigureDomainToViewModels();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to the UI layer view models
        /// </summary>
        private void ConfigureDomainToViewModels()
        {
            // Maps from Domain to UI view models
            ConfigurePlantViewModels();
            ConfigurePlantSeedViewModels();
            ConfigurePlantSeedTrayViewModels();
            ConfigurePlantStockEntryViewModels();
            ConfigurePlantStockTransactionViewModels();
            ConfigurePlantSeedSiteViewModels();
        }

        #region Configure View Models

        private void ConfigurePlantViewModels()
        {
            // Plant
            CreateMap<Plant, PlantDeleteViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenericName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpecificName));

            CreateMap<Plant, PlantEditViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenericName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpecificName));

            CreateMap<Plant, PlantListViewModel>();

            CreateMap<Plant, PlantNewViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenericName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpecificName));

            CreateMap<Plant, PlantShowViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenericName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpecificName));
               //.ForMember(uio => uio.Seeds, opt => opt.Ignore())
               //.ForMember(uio => uio.Stock, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedViewModels()
        {
            // PlantSeed
            CreateMap<PlantSeed, PlantSeedDeleteViewModel>();
            CreateMap<PlantSeed, PlantSeedEditViewModel>();
            CreateMap<PlantSeed, PlantSeedListViewModel>();
            CreateMap<PlantSeed, PlantSeedNewViewModel>()
                .ForMember(uio => uio.PlantSpecies, opt => opt.Ignore()); // don't need to map species up for new seed batch
            CreateMap<PlantSeed, PlantSeedShowViewModel>();
                //.ForMember(uio => uio.SeedTrays, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedSiteViewModels()
        {
            // PlantSeedSite
            CreateMap<PlantSeedSite, SiteDeleteViewModel>();
            CreateMap<PlantSeedSite, SiteEditViewModel>();
            CreateMap<PlantSeedSite, SiteListViewModel>();
            CreateMap<PlantSeedSite, SiteNewViewModel>();
            CreateMap<PlantSeedSite, SiteShowViewModel>();
                //.ForMember(uio => uio.SeedBatches, opt => opt.Ignore());
        }

        private void ConfigurePlantStockEntryViewModels()
        {
            // PlantStockEntry
            CreateMap<PlantStockEntry, PlantStockEntryDeleteViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryEditViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryListViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryNewViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryShowViewModel>();
                //.ForMember(uio => uio.Transactions, opt => opt.Ignore());
        }

        private void ConfigurePlantStockTransactionViewModels()
        {
            // PlantStockTransaction
            CreateMap<PlantStockTransaction, PlantStockTransactionDeleteViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionEditViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionListViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionNewViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionShowViewModel>();
        }

        private void ConfigurePlantSeedTrayViewModels()
        {
            // PlantSeedTray
            CreateMap<PlantSeedTray, TrayDeleteViewModel>();
            CreateMap<PlantSeedTray, TrayEditViewModel>();
            CreateMap<PlantSeedTray, TrayListViewModel>();
            CreateMap<PlantSeedTray, TrayNewViewModel>();
            CreateMap<PlantSeedTray, TrayShowViewModel>();
                //.ForMember(uio => uio.PlantStockTransactions, opt => opt.Ignore());
        }

        #endregion Configure View Models
    }
}