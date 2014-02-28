using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Repositories
{
    public class LinqToSqlSeedTrayRepository : LinqToSqlRepositoryBase<DAL.Entities.SeedTray, LinqToSql.Entities.SeedTray>, ISeedTrayRepository
    {
        public LinqToSqlSeedTrayRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.DatePlanted));
        }

        protected override LinqToSql.Entities.SeedTray UpdateItem(LinqToSql.Entities.SeedTray requestItem)
        {
            LinqToSql.Entities.SeedTray dbSeedTray = SelectItem(requestItem.Id);

            dbSeedTray.SeedBatchId = requestItem.SeedBatchId;
            dbSeedTray.DatePlanted = requestItem.DatePlanted;
            dbSeedTray.Treatment = requestItem.Treatment;
            dbSeedTray.ThrownOut = requestItem.ThrownOut;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
