using AutoMapper;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

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
                .ForMember(bo => bo.GenericName, opt => opt.MapFrom(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpecificName, opt => opt.MapFrom(uio => uio.Species.Trim()))
                .ForMember(bo => bo.Binomial, opt => opt.Ignore())
                //.ForMember(bo => bo.Seeds, opt => opt.Ignore())
                //.ForMember(bo => bo.Stock, opt => opt.Ignore())
                .ForMember(bo => bo.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<PlantDestroyEditModel, Plant>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantUpdateEditModel, Plant>()
                .ForMember(bo => bo.GenericName, opt => opt.MapFrom(uio => uio.Genus.Trim()))
                .ForMember(bo => bo.SpecificName, opt => opt.MapFrom(uio => uio.Species.Trim()))
                .ForMember(bo => bo.Binomial, opt => opt.Ignore());
                //.ForMember(bo => bo.Seeds, opt => opt.Ignore())
                //.ForMember(bo => bo.Stock, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedEditModels()
        {
            // PlantSeed
            CreateMap<PlantSeedCreateEditModel, PlantSeed>()
                //.ForMember(bo => bo.SeedTrays, opt => opt.Ignore())
                .ForMember(bo => bo.SpeciesBinomial, opt => opt.Ignore())
                .ForMember(bo => bo.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<PlantSeedDestroyEditModel, PlantSeed>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantSeedUpdateEditModel, PlantSeed>()
                .ForMember(bo => bo.SpeciesBinomial, opt => opt.Ignore());
                //.ForMember(bo => bo.SeedTrays, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedSiteEditModels()
        {
            // PlantSeedSite
            CreateMap<SiteCreateEditModel, PlantSeedSite>()
                //.ForMember(bo => bo.SeedBatches, opt => opt.Ignore())
                .ForMember(bo => bo.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<SiteDestroyEditModel, PlantSeedSite>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SiteUpdateEditModel, PlantSeedSite>();
                //.ForMember(bo => bo.SeedBatches, opt => opt.Ignore());
        }

        private void ConfigurePlantStockEntryEditModels()
        {
            // PlantStockEntry
            CreateMap<PlantStockEntryCreateEditModel, PlantStockEntry>()
                .ForMember(bo => bo.Id, opt => opt.Ignore())   // Id on create will come back from DB
                .ForMember(bo => bo.SpeciesBinomial, opt => opt.Ignore());
                //.ForMember(bo => bo.Transactions, opt => opt.Ignore())

            CreateMap<PlantStockEntryDestroyEditModel, PlantStockEntry>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockEntryUpdateEditModel, PlantStockEntry>()
                .ForMember(bo => bo.SpeciesBinomial, opt => opt.Ignore());
                //.ForMember(bo => bo.Transactions, opt => opt.Ignore())
        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // PlantStockTransaction
            CreateMap<PlantStockTransactionCreateEditModel, PlantStockTransaction>()
                .ForMember(bo => bo.Id, opt => opt.Ignore());                // Id on create will come back from DB

            CreateMap<PlantStockTransactionDestroyEditModel, PlantStockTransaction>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockTransactionUpdateEditModel, PlantStockTransaction>();
        }

        private void ConfigurePlantSeedTrayEditModels()
        {
            // PlantSeedTray
            CreateMap<TrayCreateEditModel, PlantSeedTray>()
                .ForMember(bo => bo.Id, opt => opt.Ignore());   // Id on create will come back from DB
                //.ForMember(bo => bo.PlantStockTransactions, opt => opt.Ignore());

            CreateMap<TrayDestroyEditModel, PlantSeedTray>()
                .ForMember(bo => bo.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<TrayUpdateEditModel, PlantSeedTray>();
                //.ForMember(bo => bo.PlantStockTransactions, opt => opt.Ignore());
        }

        #endregion Configure Edit Models
    }
}