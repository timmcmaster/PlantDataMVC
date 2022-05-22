using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class SeedBatchRepository : EFRepository<SeedBatch>, ISeedBatchRepository
    {
        public SeedBatchRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override SeedBatch GetItemById(int id)
        {
            var result = DbSet
                .Include(m => m.Species).ThenInclude(m => m.Genus)
                .Include(m => m.Site)
                .Single(m => m.Id == id);
            return result;
        }
    }
}