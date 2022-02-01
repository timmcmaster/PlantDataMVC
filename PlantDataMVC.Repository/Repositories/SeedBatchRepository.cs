using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SeedBatchRepository : EFRepository<SeedBatch>, ISeedBatchRepository
    {
        private readonly IDbContext _dbContext;

        public SeedBatchRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}