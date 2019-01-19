using Interfaces.DAL.Repository;
using PlantDataMVC.Entities.Models;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    /// <summary>
    /// Use extension methods to provide specific queries per entity type
    /// </summary>
    public static class GenusRepositoryOld
    {
        public static Genus GetItemByLatinName(this IRepository<Genus> repository, string latinName)
        {
            return repository.Queryable().FirstOrDefault(p => p.LatinName == latinName);
        }

        public static Genus GetItemWithAllSpecies(this IRepository<Genus> repository, int id)
        {
            return repository.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
    }
}
