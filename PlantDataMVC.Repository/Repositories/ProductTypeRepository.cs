using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductTypeRepository : EFRepository<ProductTypeEntityModel>, IProductTypeRepository
    {
        public ProductTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}