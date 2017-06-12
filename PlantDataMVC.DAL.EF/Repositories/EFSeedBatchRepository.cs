using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFSeedBatchRepository : EFRepositoryBase<SeedBatch>, ISeedBatchRepository<SeedBatch>
    {
        public EFSeedBatchRepository(DbContext dbContext)
            : base(dbContext)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.DateCollected));
        }
    }
}
