using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMVC.DAL.LinqToSql.Repositories
{
    public class LinqToSqlJournalEntryTypeRepository : LinqToSqlRepositoryBase<DAL.Entities.JournalEntryType, LinqToSql.Entities.JournalEntryType>, IJournalEntryTypeRepository
    {
        public LinqToSqlJournalEntryTypeRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.Name));
        }

        protected override LinqToSql.Entities.JournalEntryType UpdateItem(LinqToSql.Entities.JournalEntryType requestItem)
        {
            LinqToSql.Entities.JournalEntryType dbJournalEntryType = SelectItem(requestItem.Id);

            dbJournalEntryType.Name = requestItem.Name;
            dbJournalEntryType.Effect = requestItem.Effect;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
