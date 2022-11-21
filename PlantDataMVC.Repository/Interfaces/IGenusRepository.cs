using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IGenusRepository : IRepositoryAsync<GenusEntityModel>
    {
        GenusEntityModel GetItemByLatinName(string latinName);
        GenusEntityModel GetItemWithAllSpecies(int id);
    }
}
