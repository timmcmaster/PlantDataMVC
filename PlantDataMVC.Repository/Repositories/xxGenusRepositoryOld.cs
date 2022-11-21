using System.Linq;
using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Repositories
{
    /// <summary>
    ///     Use extension methods to provide specific queries per entity type
    /// </summary>
    public static class GenusRepositoryOld
    {
        public static GenusEntityModel GetItemByLatinName(this IRepository<GenusEntityModel> repository, string latinName)
        {
            return repository.Queryable().FirstOrDefault(p => p.LatinName == latinName);
        }

        public static GenusEntityModel GetItemWithAllSpecies(this IRepository<GenusEntityModel> repository, int id)
        {
            return repository.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
    }
}