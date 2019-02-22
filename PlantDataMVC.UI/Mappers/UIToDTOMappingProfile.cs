using AutoMapper;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels.SeedBatch;
using PlantDataMVC.UI.Models.EditModels.SeedTray;
using Genus = PlantDataMVC.UI.Models.EditModels.Genus;
using Plant = PlantDataMVC.UI.Models.EditModels.Plant;
using PlantStock = PlantDataMVC.UI.Models.EditModels.PlantStock;
using Site = PlantDataMVC.UI.Models.EditModels.Site;
using Transaction = PlantDataMVC.UI.Models.EditModels.Transaction;

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
            ConfigureSeedBatchEditModels();
            ConfigureSeedTrayEditModels();
            ConfigurePlantStockEditModels();
            ConfigureTransactionEditModels();
            ConfigureSiteEditModels();
            // Maps from UI edit models to domain
        }

        #region Configure Edit Models

        private void ConfigureGenusEditModels()
        {
            // Plant
            CreateMap<Genus.GenusCreateEditModel, CreateUpdateGenusDto>()
                .ForMember(dto => dto.LatinName, opt => opt.MapFrom(uio => uio.LatinName))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Genus.GenusDestroyEditModel, GenusDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Genus.GenusUpdateEditModel, CreateUpdateGenusDto>()
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
            CreateMap<Plant.PlantCreateEditModel, SpeciesDto>()
                .ForMember(dto => dto.CommonName, opt => opt.MapFrom(uio => uio.CommonName))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(uio => uio.Description))
                .ForMember(dto => dto.GenusId, opt => opt.Ignore())                             // TODO: handle creation without GenusID  
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.Native, opt => opt.MapFrom(uio => uio.Native))
                .ForMember(dto => dto.PlantStocks, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.PropagationTime, opt => opt.MapFrom(uio => uio.PropagationTime))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore())                         // TODO: check about mapping back collection
                .ForMember(dto => dto.SpecificName, opt => opt.MapFrom(uio => uio.Species));

            CreateMap<Plant.PlantDestroyEditModel, SpeciesDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Plant.PlantUpdateEditModel, SpeciesDto>()
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

        private void ConfigureSeedBatchEditModels()
        {
            // SeedBatchDTO
            CreateMap<SeedBatchCreateEditModel, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                          // Id on create will come back from DB
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<SeedBatchDestroyEditModel, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SeedBatchUpdateEditModel, SeedBatchDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.Location, opt => opt.MapFrom(uio => uio.Location))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.SeedTrays, opt => opt.Ignore())                   // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteId, opt => opt.MapFrom(uio => uio.SiteId))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigureSiteEditModels()
        {
            // SiteDTO
            CreateMap<Site.SiteCreateEditModel, SiteDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore()) // Id on create will come back from DB
                .ForMember(dto => dto.Latitude, opt => opt.MapFrom(uio => uio.Latitude))
                .ForMember(dto => dto.Longitude, opt => opt.MapFrom(uio => uio.Longitude))
                .ForMember(dto => dto.SeedBatches, opt => opt.Ignore()) // TODO: check about mapping back collection
                .ForMember(dto => dto.SiteName, opt => opt.MapFrom(uio => uio.SiteName))
                .ForMember(dto => dto.Suburb, opt => opt.MapFrom(uio => uio.Suburb));
                

            CreateMap<Site.SiteDestroyEditModel, SiteDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Site.SiteUpdateEditModel, SiteDto>()
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
            CreateMap<PlantStock.PlantStockCreateEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));

            CreateMap<PlantStock.PlantStockDestroyEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PlantStock.PlantStockUpdateEditModel, PlantStockDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())      // TODO: check about mapping back collection
                .ForMember(dto => dto.ProductTypeId, opt => opt.MapFrom(uio => uio.ProductTypeId))
                .ForMember(dto => dto.QuantityInStock, opt => opt.MapFrom(uio => uio.QuantityInStock))
                .ForMember(dto => dto.SpeciesId, opt => opt.MapFrom(uio => uio.SpeciesId));
        }

        private void ConfigureTransactionEditModels()
        {
            // JournalEntryDTO
            CreateMap<Transaction.TransactionCreateEditModel, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.Ignore())                 // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));

            CreateMap<Transaction.TransactionDestroyEditModel, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Transaction.TransactionUpdateEditModel, JournalEntryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForMember(dto => dto.JournalEntryTypeId, opt => opt.MapFrom(uio => uio.TransactionType.Id))
                .ForMember(dto => dto.Notes, opt => opt.MapFrom(uio => uio.Notes))
                .ForMember(dto => dto.PlantStockId, opt => opt.MapFrom(uio => uio.PlantStockId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(uio => uio.Quantity))
                .ForMember(dto => dto.SeedTrayId, opt => opt.MapFrom(uio => uio.SeedTrayId))
                .ForMember(dto => dto.Source, opt => opt.MapFrom(uio => uio.TransactionSource))
                .ForMember(dto => dto.TransactionDate, opt => opt.MapFrom(uio => uio.TransactionDate));
        }

        private void ConfigureSeedTrayEditModels()
        {
            // SeedTray
            CreateMap<SeedTrayCreateEditModel, SeedTrayDto>()
                .ForMember(dto => dto.DatePlanted, opt => opt.MapFrom(uio => uio.DatePlanted))
                .ForMember(dto => dto.Id, opt => opt.Ignore())                                  // Id on create will come back from DB
                .ForMember(dto => dto.JournalEntries, opt => opt.Ignore())                      // TODO: check about mapping back collection
                .ForMember(dto => dto.SeedBatchId, opt => opt.MapFrom(uio => uio.SeedBatchId))
                .ForMember(dto => dto.ThrownOut, opt => opt.MapFrom(uio => uio.ThrownOut))
                .ForMember(dto => dto.Treatment, opt => opt.MapFrom(uio => uio.Treatment));

            CreateMap<SeedTrayDestroyEditModel, SeedTrayDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(uio => uio.Id))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<SeedTrayUpdateEditModel, SeedTrayDto>()
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