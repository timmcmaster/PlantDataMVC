using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.UI.ServiceLayerAccess;

namespace PlantDataMvc3.UI.Mappers
{
    public class BasicProfile: Profile
    {
        protected override void Configure()
        {
            ConfigureDomainToViewModels();

            ConfigureEditModelsToDomain();
        }

        /// <summary>
        /// Configure the mappings from the App/Business Layer objects to and from the UI layer view models
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

        #region Configure View Models

        private void ConfigurePlantViewModels()
        {
            // Plant
            Mapper.CreateMap<Plant, PlantDeleteViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            Mapper.CreateMap<Plant, PlantEditViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            Mapper.CreateMap<Plant, PlantListViewModel>();

            Mapper.CreateMap<Plant, PlantNewViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));

            Mapper.CreateMap<Plant, PlantShowViewModel>()
               .ForMember(uio => uio.Genus, opt => opt.MapFrom<String>(bo => bo.GenusLatinName))
               .ForMember(uio => uio.Species, opt => opt.MapFrom<String>(bo => bo.SpeciesLatinName));
        }

        private void ConfigurePlantSeedViewModels()
        {
            // PlantSeed
            Mapper.CreateMap<PlantSeed, PlantSeedDeleteViewModel>();
            Mapper.CreateMap<PlantSeed, PlantSeedEditViewModel>();
            Mapper.CreateMap<PlantSeed, PlantSeedListViewModel>();
            Mapper.CreateMap<PlantSeed, PlantSeedNewViewModel>();
            Mapper.CreateMap<PlantSeed, PlantSeedShowViewModel>();
        }

        private void ConfigurePlantSeedSiteViewModels()
        {
            // PlantSeedSite
            Mapper.CreateMap<PlantSeedSite, SiteDeleteViewModel>();
            Mapper.CreateMap<PlantSeedSite, SiteEditViewModel>();
            Mapper.CreateMap<PlantSeedSite, SiteListViewModel>();
            Mapper.CreateMap<PlantSeedSite, SiteNewViewModel>();
            Mapper.CreateMap<PlantSeedSite, SiteShowViewModel>();
        }

        private void ConfigurePlantStockEntryViewModels()
        {
            // PlantStockEntry
            Mapper.CreateMap<PlantStockEntry, PlantStockEntryDeleteViewModel>();
            Mapper.CreateMap<PlantStockEntry, PlantStockEntryEditViewModel>()
                .ForMember(uio => uio.ProductTypes,
                    opt => opt.MapFrom<IList<PlantProductType>>(
                        bo => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantProductType>().List(new ListRequest<PlantProductType>()).Items));

            Mapper.CreateMap<PlantStockEntry, PlantStockEntryListViewModel>();
            Mapper.CreateMap<PlantStockEntry, PlantStockEntryNewViewModel>()
                .ForMember(uio => uio.ProductTypes,
                    opt => opt.MapFrom<IList<PlantProductType>>(
                        bo => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantProductType>().List(new ListRequest<PlantProductType>()).Items));

            Mapper.CreateMap<PlantStockEntry, PlantStockEntryShowViewModel>();
        }

        private void ConfigurePlantStockTransactionViewModels()
        {
            // PlantStockTransaction
            Mapper.CreateMap<PlantStockTransaction, PlantStockTransactionDeleteViewModel>();
            Mapper.CreateMap<PlantStockTransaction, PlantStockTransactionEditViewModel>()
                .ForMember(uio => uio.TransactionTypes,
                        opt => opt.MapFrom<IList<PlantStockTransactionType>>(
                            bo => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockTransactionType>().List(new ListRequest<PlantStockTransactionType>()).Items));

            Mapper.CreateMap<PlantStockTransaction, PlantStockTransactionListViewModel>();
            Mapper.CreateMap<PlantStockTransaction, PlantStockTransactionNewViewModel>()
                .ForMember(uio => uio.TransactionTypes,
                        opt => opt.MapFrom<IList<PlantStockTransactionType>>(
                            bo => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockTransactionType>().List(new ListRequest<PlantStockTransactionType>()).Items));

            Mapper.CreateMap<PlantStockTransaction, PlantStockTransactionShowViewModel>();
        }

        private void ConfigurePlantSeedTrayViewModels()
        {
            // PlantSeedTray
            Mapper.CreateMap<PlantSeedTray, TrayDeleteViewModel>();
            Mapper.CreateMap<PlantSeedTray, TrayEditViewModel>();
            Mapper.CreateMap<PlantSeedTray, TrayListViewModel>();
            Mapper.CreateMap<PlantSeedTray, TrayNewViewModel>();
            Mapper.CreateMap<PlantSeedTray, TrayShowViewModel>();
        }

        #endregion Configure View Models

        #region Configure Edit Models

        private void ConfigurePlantEditModels()
        {
            // Plant
            Mapper.CreateMap<PlantCreateEditModel, Plant>()
                .ForMember(bo => bo.GenusLatinName, opt => opt.MapFrom<String>(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(uio => uio.Species.Trim()));

            Mapper.CreateMap<PlantDestroyEditModel, Plant>();

            Mapper.CreateMap<PlantUpdateEditModel, Plant>()
                .ForMember(bo => bo.GenusLatinName, opt => opt.MapFrom<String>(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpeciesLatinName, opt => opt.MapFrom<String>(uio => uio.Species.Trim()));

        }

        private void ConfigurePlantSeedEditModels()
        {
            // PlantSeed
            Mapper.CreateMap<PlantSeedCreateEditModel, PlantSeed>();
            Mapper.CreateMap<PlantSeedDestroyEditModel, PlantSeed>();
            Mapper.CreateMap<PlantSeedUpdateEditModel, PlantSeed>();

        }

        private void ConfigurePlantSeedSiteEditModels()
        {
            // PlantSeedSite
            Mapper.CreateMap<SiteCreateEditModel, PlantSeedSite>();
            Mapper.CreateMap<SiteDestroyEditModel, PlantSeedSite>();
            Mapper.CreateMap<SiteUpdateEditModel, PlantSeedSite>();

        }

        private void ConfigurePlantStockEntryEditModels()
        {
            // PlantStockEntry
            Mapper.CreateMap<PlantStockEntryCreateEditModel, PlantStockEntry>()
                .ForMember(bo => bo.ProductType,
                            opt => opt.MapFrom<PlantProductType>(
                                uio => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantProductType>().View(new ViewRequest<PlantProductType>(uio.ProductTypeId)).Item));

            Mapper.CreateMap<PlantStockEntryDestroyEditModel, PlantStockEntry>();
            Mapper.CreateMap<PlantStockEntryUpdateEditModel, PlantStockEntry>()
                .ForMember(bo => bo.ProductType,
                            opt => opt.MapFrom<PlantProductType>(
                                uio => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantProductType>().View(new ViewRequest<PlantProductType>(uio.ProductTypeId)).Item));

        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // PlantStockTransaction
            Mapper.CreateMap<PlantStockTransactionCreateEditModel, PlantStockTransaction>()
                .ForMember(bo => bo.TransactionType,
                            opt => opt.MapFrom<PlantStockTransactionType>(
                                uio => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockTransactionType>().View(new ViewRequest<PlantStockTransactionType>(uio.TransactionTypeId)).Item));

            Mapper.CreateMap<PlantStockTransactionDestroyEditModel, PlantStockTransaction>();
            Mapper.CreateMap<PlantStockTransactionUpdateEditModel, PlantStockTransaction>()
                .ForMember(bo => bo.TransactionType,
                            opt => opt.MapFrom<PlantStockTransactionType>(
                                uio => ServiceLayerManager.Instance().GetServiceLayer().GetDataService<PlantStockTransactionType>().View(new ViewRequest<PlantStockTransactionType>(uio.TransactionTypeId)).Item));

        }

        private void ConfigurePlantSeedTrayEditModels()
        {
            // PlantSeedTray
            Mapper.CreateMap<TrayCreateEditModel, PlantSeedTray>();
            Mapper.CreateMap<TrayDestroyEditModel, PlantSeedTray>();
            Mapper.CreateMap<TrayUpdateEditModel, PlantSeedTray>();
        }

        #endregion Configure Edit Models
    }
}