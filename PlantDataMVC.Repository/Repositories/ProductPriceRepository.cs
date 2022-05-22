using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductPriceRepository : EFRepository<ProductPrice>, IProductPriceRepository
    {
        public ProductPriceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}