using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SaleEventRepository : EFRepository<SaleEventEntityModel>, ISaleEventRepository
    {
        public SaleEventRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}