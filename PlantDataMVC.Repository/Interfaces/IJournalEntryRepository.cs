using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IJournalEntryRepository : IRepositoryAsync<JournalEntryEntityModel>
    {
        int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId);
    }
}
