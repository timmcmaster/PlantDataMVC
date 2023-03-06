using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class PriceListTypeRepository : EFRepository<PriceListTypeEntityModel>, IPriceListTypeRepository
    {
        public PriceListTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public override PriceListTypeEntityModel GetItemById(int id)
        {
            var result = DbSet
                .Include(m => m.ProductPrices).ThenInclude(p => p.ProductType)
                .Single(m => m.Id == id);
            
            return result;
        }
    }
}