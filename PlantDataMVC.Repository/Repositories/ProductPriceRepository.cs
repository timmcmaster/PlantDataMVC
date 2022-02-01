using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductPriceRepository : EFRepository<ProductPrice>, IProductPriceRepository
    {
        private readonly IDbContext _dbContext;

        public ProductPriceRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}