using System.Linq;
using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Repository.Repositories
{
    /// <summary>
    ///     Use extension methods to provide specific queries per entity type
    /// </summary>
    public static class JournalEntryRepository
    {
        public static int GetStockCountForProduct(this IRepository<JournalEntry> repository, int plantStockId)
        {
            return repository
                   .Queryable()
                   .Where(je => je.PlantStockId == plantStockId)
                   .Select(je => je.Quantity * je.JournalEntryType.Effect)
                   .Sum();
        }
    }
}