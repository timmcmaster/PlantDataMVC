using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFSeedBatchRepository : EFRepositoryBase<SeedBatch>, ILocalSeedBatchRepository<SeedBatch>
    {
        public EFSeedBatchRepository(DbContext dbContext)
            : base(dbContext)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.DateCollected));
        }
    }
}
