using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IGenusRepository : IRepositoryAsync<Genus>
    {
        Genus GetItemByLatinName(string latinName);
        Genus GetItemWithAllSpecies(int id);
    }
}
