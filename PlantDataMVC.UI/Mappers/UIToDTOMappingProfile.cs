using AutoMapper;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Mappers
{
    public class UIToDTOMappingProfile : Profile
    {
        public UIToDTOMappingProfile()
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
                .ForMember(dto => dto.GenericName, opt => opt.MapFrom(uio => uio.Genus.Trim()))
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species.Trim()))
                .ForMember(dto => dto.Binomial, opt => opt.Ignore())
                //.ForMember(dto => dto.Seeds, opt => opt.Ignore())
                //.ForMember(dto => dto.Stock, opt => opt.Ignore())
                .ForMember(dto => dto.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<PlantDestroyEditModel, Plant>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantUpdateEditModel, Plant>()
                .ForMember(dto => dto.GenericName, opt => opt.MapFrom(uio => uio.Genus.Trim()))
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species.Trim()))
                .ForMember(dto => dto.Binomial, opt => opt.Ignore());
                //.ForMember(dto => dto.Seeds, opt => opt.Ignore())
                //.ForMember(dto => dto.Stock, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedEditModels()
        {
            // SeedBatchDTO
            CreateMap<PlantSeedCreateEditModel, SeedBatchDTO>()
                //.ForMember(dto => dto.SeedTrays, opt => opt.Ignore())
                .ForMember(dto => dto.SpeciesBinomial, opt => opt.Ignore())
                .ForMember(dto => dto.SiteName, opt => opt.Ignore())
                .ForMember(dto => dto.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<PlantSeedDestroyEditModel, SeedBatchDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantSeedUpdateEditModel, SeedBatchDTO>()
                .ForMember(dto => dto.SpeciesBinomial, opt => opt.Ignore())
                .ForMember(dto => dto.SiteName, opt => opt.Ignore());
                //.ForMember(dto => dto.SeedTrays, opt => opt.Ignore());
        }

        private void ConfigurePlantSeedSiteEditModels()
        {
            // PlantSeedSite
            CreateMap<SiteCreateEditModel, SiteDTO>()
                //.ForMember(dto => dto.SeedBatches, opt => opt.Ignore())
                .ForMember(dto => dto.Id, opt => opt.Ignore());   // Id on create will come back from DB

            CreateMap<SiteDestroyEditModel, SiteDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SiteUpdateEditModel, SiteDTO>();
                //.ForMember(dto => dto.SeedBatches, opt => opt.Ignore());
        }

        private void ConfigurePlantStockEntryEditModels()
        {
            // PlantStockDTO
            CreateMap<PlantStockEntryCreateEditModel, PlantStockDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())   // Id on create will come back from DB
                .ForMember(dto => dto.SpeciesBinomial, opt => opt.Ignore());
                //.ForMember(dto => dto.Transactions, opt => opt.Ignore())

            CreateMap<PlantStockEntryDestroyEditModel, PlantStockDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockEntryUpdateEditModel, PlantStockDTO>()
                .ForMember(dto => dto.SpeciesBinomial, opt => opt.Ignore());
                //.ForMember(dto => dto.Transactions, opt => opt.Ignore())
        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<PlantStockTransactionCreateEditModel, JournalEntryDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore());                // Id on create will come back from DB

            CreateMap<PlantStockTransactionDestroyEditModel, JournalEntryDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockTransactionUpdateEditModel, JournalEntryDTO>();
        }

        private void ConfigurePlantSeedTrayEditModels()
        {
            // PlantSeedTray
            CreateMap<TrayCreateEditModel, SeedTrayDTO>()
                .ForMember(dto => dto.Id, opt => opt.Ignore());   // Id on create will come back from DB
                //.ForMember(dto => dto.PlantStockTransactions, opt => opt.Ignore());

            CreateMap<TrayDestroyEditModel, SeedTrayDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<TrayUpdateEditModel, SeedTrayDTO>();
                //.ForMember(dto => dto.PlantStockTransactions, opt => opt.Ignore());
        }

        #endregion Configure Edit Models
    }
}