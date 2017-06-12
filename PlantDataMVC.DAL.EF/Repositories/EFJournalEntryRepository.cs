using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFJournalEntryRepository : EFRepositoryBase<JournalEntry>, IJournalEntryRepository<JournalEntry>
    {
        public EFJournalEntryRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(je => je.TransactionDate));
        }

    }
}
