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
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            CreateMap<Plant, PlantEditViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            CreateMap<Plant, PlantListViewModel>();

            CreateMap<Plant, PlantNewViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            CreateMap<Plant, PlantShowViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));
        }

        private void ConfigurePlantSeedViewModels()
        {
            // PlantSeed
            CreateMap<PlantSeed, PlantSeedDeleteViewModel>();
            CreateMap<PlantSeed, PlantSeedEditViewModel>();
            CreateMap<PlantSeed, PlantSeedListViewModel>();
            CreateMap<PlantSeed, PlantSeedNewViewModel>();
            CreateMap<PlantSeed, PlantSeedShowViewModel>();
        }

        private void ConfigurePlantSeedSiteViewModels()
        {
            // PlantSeedSite
            CreateMap<PlantSeedSite, SiteDeleteViewModel>();
            CreateMap<PlantSeedSite, SiteEditViewModel>();
            CreateMap<PlantSeedSite, SiteListViewModel>();
            CreateMap<PlantSeedSite, SiteNewViewModel>();
            CreateMap<PlantSeedSite, SiteShowViewModel>();
        }

        private void ConfigurePlantStockEntryViewModels()
        {
            // PlantStockEntry
            CreateMap<PlantStockEntry, PlantStockEntryDeleteViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryEditViewModel>()
                .ForMember(uio => uio.ProductTypes, opt => opt.Ignore());   // TODO: Go back to detail on querying ref data from UI 
                //.ForMember(uio => uio.ProductTypes,
                //    opt => opt.MapFrom<IList<PlantProductType>>(
                //        bo => _serviceLayer.GetDataService<PlantProductType>().List(new ListRequest<PlantProductType>()).Items));

            CreateMap<PlantStockEntry, PlantStockEntryListViewModel>();
            CreateMap<PlantStockEntry, PlantStockEntryNewViewModel>()
                .ForMember(uio => uio.ProductTypes, opt => opt.Ignore());   // TODO: Go back to detail on querying ref data from UI 
                //.ForMember(uio => uio.ProductTypes,
                //    opt => opt.MapFrom<IList<PlantProductType>>(
                //        bo => _serviceLayer.GetDataService<PlantProductType>().List(new ListRequest<PlantProductType>()).Items));

            CreateMap<PlantStockEntry, PlantStockEntryShowViewModel>();
        }

        private void ConfigurePlantStockTransactionViewModels()
        {
            // PlantStockTransaction
            CreateMap<PlantStockTransaction, PlantStockTransactionDeleteViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionEditViewModel>()
                .ForMember(uio => uio.TransactionTypes, opt => opt.Ignore());   // TODO: Go back to detail on querying ref data from UI 
                //.ForMember(uio => uio.TransactionTypes,
                //        opt => opt.MapFrom<IList<PlantStockTransactionType>>(
                //            bo => _serviceLayer.GetDataService<PlantStockTransactionType>().List(new ListRequest<PlantStockTransactionType>()).Items));

            CreateMap<PlantStockTransaction, PlantStockTransactionListViewModel>();
            CreateMap<PlantStockTransaction, PlantStockTransactionNewViewModel>()
                .ForMember(uio => uio.TransactionTypes, opt => opt.Ignore());   // TODO: Go back to detail on querying ref data from UI 
                //.ForMember(uio => uio.TransactionTypes,
                //        opt => opt.MapFrom<IList<PlantStockTransactionType>>(
                //            bo => _serviceLayer.GetDataService<PlantStockTransactionType>().List(new ListRequest<PlantStockTransactionType>()).Items));

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
        }

        #endregion Configure View Models
    }
}