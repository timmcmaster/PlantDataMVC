using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMVC.DAL.LinqToSql.Repositories
{
    public class LinqToSqlJournalEntryRepository : LinqToSqlRepositoryBase<DAL.Entities.JournalEntry, LinqToSql.Entities.JournalEntry>, IJournalEntryRepository
    {
        public LinqToSqlJournalEntryRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.TransactionDate));
        }

        protected override LinqToSql.Entities.JournalEntry UpdateItem(LinqToSql.Entities.JournalEntry requestItem)
        {
            LinqToSql.Entities.JournalEntry dbJournalEntry = SelectItem(requestItem.Id);

            dbJournalEntry.JournalEntryTypeId = requestItem.JournalEntryTypeId;
            dbJournalEntry.PlantStockId = requestItem.PlantStockId;
            dbJournalEntry.TransactionDate = requestItem.TransactionDate;
            dbJournalEntry.Quantity = requestItem.Quantity;
            dbJournalEntry.SeedTrayId = requestItem.SeedTrayId;
            dbJournalEntry.Source = requestItem.Source;
            dbJournalEntry.Notes = requestItem.Notes;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
