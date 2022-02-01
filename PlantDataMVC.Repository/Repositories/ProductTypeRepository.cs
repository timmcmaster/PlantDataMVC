using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductTypeRepository : EFRepository<ProductType>, IProductTypeRepository
    {
        private readonly IDbContext _dbContext;

        public ProductTypeRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}