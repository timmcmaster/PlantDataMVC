using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMVC.DAL.LinqToSql.Repositories
{
    public class LinqToSqlSeedBatchRepository : LinqToSqlRepositoryBase<DAL.Entities.SeedBatch, LinqToSql.Entities.SeedBatch>, ISeedBatchRepository
    {
        public LinqToSqlSeedBatchRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.DateCollected));
        }

        protected override LinqToSql.Entities.SeedBatch UpdateItem(LinqToSql.Entities.SeedBatch requestItem)
        {
            LinqToSql.Entities.SeedBatch dbSeedBatch = SelectItem(requestItem.Id);

            dbSeedBatch.SpeciesId = requestItem.SpeciesId;
            dbSeedBatch.DateCollected = requestItem.DateCollected;
            dbSeedBatch.Location = requestItem.Location;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
