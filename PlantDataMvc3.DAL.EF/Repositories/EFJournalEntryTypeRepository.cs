using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFJournalEntryTypeRepository : EFRepositoryBase<JournalEntryType>, ILocalJournalEntryTypeRepository<JournalEntryType>
    {
        public EFJournalEntryTypeRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(jet => jet.Name));
        }
    }
}
