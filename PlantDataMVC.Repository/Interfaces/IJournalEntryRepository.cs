using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IJournalEntryRepository : IRepositoryAsync<JournalEntryEntityModel>
    {
        int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId);
        List<JournalEntryStockSummaryModel> GetStockCounts(int? speciesId, int? productTypeId, bool includeEntries = false);
    }
}
