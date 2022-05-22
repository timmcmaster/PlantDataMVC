using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class PlantStockRepository : EFRepository<PlantStock>, IPlantStockRepository
    {
        public PlantStockRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public override PlantStock GetItemById(int id)
        {
            var result = DbSet
                .Include(m => m.Species).ThenInclude(m => m.Genus)
                .Include(m => m.ProductType)
                .Single(m => m.Id == id);
            return result;
        }
    }
}