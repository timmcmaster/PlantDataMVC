using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFJournalEntryRepository : EFRepositoryBase<JournalEntry>, ILocalJournalEntryRepository<JournalEntry>
    {
        public EFJournalEntryRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(je => je.TransactionDate));
        }

    }
}
