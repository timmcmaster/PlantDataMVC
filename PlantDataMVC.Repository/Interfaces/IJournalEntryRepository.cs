using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IJournalEntryRepository : IRepositoryAsync<JournalEntry>
    {
        int GetStockCountForProduct(int plantStockId);
    }
}
