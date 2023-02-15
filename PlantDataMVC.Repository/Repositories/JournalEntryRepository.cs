using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryRepository : EFRepository<JournalEntryEntityModel>, IJournalEntryRepository
    {
        public JournalEntryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override JournalEntryEntityModel GetItemById(int id)
        {
            var result = DbSet.Include(m => m.JournalEntryType).Single(m => m.Id == id);
            return result;
        }

        public int GetStockCountForProduct(int plantStockId)
        {
            return this
                   .Queryable(useTracking: false)
                   .Where(je => je.PlantStockId == plantStockId)
                   .Select(je => je.Quantity * je.JournalEntryType.Effect)
                   .Sum();
        }
    }
}