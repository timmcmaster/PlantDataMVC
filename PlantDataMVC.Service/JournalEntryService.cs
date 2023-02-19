using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using PlantDataMVC.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service
{
    public interface IJournalEntryService : IService<JournalEntryEntityModel>
    {
        int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId);
        IEnumerable<JournalEntryStockSummaryModel> GetStockCounts(int? speciesId, int? productTypeId);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class JournalEntryService : Service<JournalEntryEntityModel>, IJournalEntryService
    {
        private readonly IJournalEntryRepository _repository;
        public JournalEntryService(IJournalEntryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<JournalEntryStockSummaryModel> GetStockCounts(int? speciesId, int? productTypeId)
        {
            return _repository.GetStockCounts(speciesId,productTypeId);
        }

        public int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId)
        {
            return _repository.GetStockCountForSpeciesAndProduct(speciesId, productTypeId);
        }

    }
}