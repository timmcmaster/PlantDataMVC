using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class GenusRepository : EFRepository<GenusEntityModel>, IGenusRepository
    {
        public GenusRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public GenusEntityModel GetItemByLatinName(string latinName)
        {
            return this.Queryable().FirstOrDefault(g => g.LatinName == latinName);

        }

        public GenusEntityModel GetItemWithAllSpecies(int id)
        {
            return this.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
    }
}