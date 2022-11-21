using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class PlantStockRepository : EFRepository<PlantStockEntityModel>, IPlantStockRepository
    {
        public PlantStockRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public override PlantStockEntityModel GetItemById(int id)
        {
            var result = DbSet
                .Include(m => m.Species).ThenInclude(m => m.Genus)
                .Include(m => m.ProductType)
                .Single(m => m.Id == id);
            return result;
        }
    }
}