using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface ISpeciesRepository : IRepositoryAsync<SpeciesEntityModel>
    {
    }
}
