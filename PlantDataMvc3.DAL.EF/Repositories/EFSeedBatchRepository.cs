using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
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
