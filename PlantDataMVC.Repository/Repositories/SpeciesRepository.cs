using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class SpeciesRepository : EFRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override Species GetItemById(int id)
        {
            var result = DbSet.Include(m => m.Genus).Single(m => m.Id == id);
            return result;
        }
    }
}