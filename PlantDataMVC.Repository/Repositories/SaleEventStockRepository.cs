using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SaleEventStockRepository : EFRepository<SaleEventStockEntityModel>, ISaleEventStockRepository
    {
        public SaleEventStockRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}