using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class SaleEventRepository : EFRepository<SaleEventEntityModel>, ISaleEventRepository
    {
        public SaleEventRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public override SaleEventEntityModel GetItemById(int id)
        {
            var result = DbSet.Include(m => m.SaleEventStock).ThenInclude(m => m.Species).ThenInclude(m => m.Genus)
                              .Include(m => m.SaleEventStock).ThenInclude(m => m.ProductType)
                              .Single(m => m.Id == id);

            return result;
        }

    }
}