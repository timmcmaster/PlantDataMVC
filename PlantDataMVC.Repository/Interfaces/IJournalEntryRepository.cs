using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Models;
using System.Collections.Generic;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IJournalEntryRepository : IRepositoryAsync<JournalEntryEntityModel>
    {
        List<JournalEntryStockSummaryModel> GetStockCounts(int? speciesId, int? productTypeId);

        int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId);
    }
}
