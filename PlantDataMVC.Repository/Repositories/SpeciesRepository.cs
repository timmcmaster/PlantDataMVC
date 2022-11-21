using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class SpeciesRepository : EFRepository<SpeciesEntityModel>, ISpeciesRepository
    {
        public SpeciesRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override SpeciesEntityModel GetItemById(int id)
        {
            var result = DbSet.Include(m => m.Genus).Single(m => m.Id == id);
            return result;
        }
    }
}