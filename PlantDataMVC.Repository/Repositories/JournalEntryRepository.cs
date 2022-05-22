using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryRepository : EFRepository<JournalEntry>, IJournalEntryRepository
    {
        public JournalEntryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override JournalEntry GetItemById(int id)
        {
            var result = DbSet.Include(m => m.JournalEntryType).Single(m => m.Id == id);
            return result;
        }

        public int GetStockCountForProduct(int plantStockId)
        {
            return this
                   .Queryable()
                   .Where(je => je.PlantStockId == plantStockId)
                   .Select(je => je.Quantity * je.JournalEntryType.Effect)
                   .Sum();
        }
    }
}