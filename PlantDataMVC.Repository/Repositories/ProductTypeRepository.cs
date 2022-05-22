using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductTypeRepository : EFRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}