using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class GenusRepository : EFRepository<Genus>, IGenusRepository
    {
        public GenusRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Genus GetItemByLatinName(string latinName)
        {
            return this.Queryable().FirstOrDefault(g => g.LatinName == latinName);

        }

        public Genus GetItemWithAllSpecies(int id)
        {
            return this.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
    }
}