using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class StocktakeLineRepository : EFRepository<StocktakeLineEntityModel>, IStocktakeLineRepository
    {
        public StocktakeLineRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}