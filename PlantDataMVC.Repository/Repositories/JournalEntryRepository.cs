using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryRepository : EFRepository<JournalEntry>, IJournalEntryRepository
    {
        private readonly IDbContext _dbContext;

        public JournalEntryRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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