using AutoMapper;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Mappers
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
            CreateMap<GenusCreateEditModel, CreateUpdateGenusDto>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<GenusDestroyEditModel, GenusDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<GenusUpdateEditModel, CreateUpdateGenusDto>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
                .ForAllOtherMembers(opt => opt.Ignore());

            //CreateMap<GenusUpdateEditModel, GenusDto>()
            //    .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
            //    .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
            //    .ForMember(dto => dto.Species, opt => opt.Ignore());     // TODO: check about mapping back collection
        }

        private void ConfigurePlantEditModels()
        {
            // Plant
            CreateMap<PlantCreateEditModel, SpeciesDto>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.Ignore())                             // TODO: handle creation without GenusID  
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));

            CreateMap<PlantDestroyEditModel, SpeciesDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantUpdateEditModel, SpeciesDto>()
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
            CreateMap<PlantSeedCreateEditModel, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                          // Id on create will come back from DB
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantSeedDestroyEditModel, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantSeedUpdateEditModel, SeedBatchDto>()
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
            CreateMap<SiteCreateEditModel, SiteDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore()) // Id on create will come back from DB
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore()) // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));
                

            CreateMap<SiteDestroyEditModel, SiteDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SiteUpdateEditModel, SiteDto>()
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
            CreateMap<PlantStockEntryCreateEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductType.Id))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantStockEntryDestroyEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockEntryUpdateEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductType.Id))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigurePlantStockTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<PlantStockTransactionCreateEditModel, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                 // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockEntryId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));

            CreateMap<PlantStockTransactionDestroyEditModel, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStockTransactionUpdateEditModel, JournalEntryDto>()
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
            CreateMap<TrayCreateEditModel, SeedTrayDto>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));

            CreateMap<TrayDestroyEditModel, SeedTrayDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<TrayUpdateEditModel, SeedTrayDto>()
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