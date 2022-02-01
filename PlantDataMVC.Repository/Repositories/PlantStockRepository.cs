using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class PlantStockRepository : EFRepository<PlantStock>, IPlantStockRepository
    {
        private readonly IDbContext _dbContext;

        public PlantStockRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}