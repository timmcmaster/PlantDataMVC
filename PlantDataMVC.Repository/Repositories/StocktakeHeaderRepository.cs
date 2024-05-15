using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class StocktakeHeaderRepository : EFRepository<StocktakeHeaderEntityModel>, IStocktakeHeaderRepository
    {
        public StocktakeHeaderRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}