using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFJournalEntryTypeRepository : EFRepositoryBase<JournalEntryType>, IJournalEntryTypeRepository<JournalEntryType>
    {
        public EFJournalEntryTypeRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(jet => jet.Name));
        }
    }
}
