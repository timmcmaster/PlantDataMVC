using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductPriceRepository : EFRepository<ProductPriceEntityModel>, IProductPriceRepository
    {
        public ProductPriceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}