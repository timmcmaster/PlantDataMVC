using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface ISpeciesService : IService<SpeciesEntityModel>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SpeciesService : Service<SpeciesEntityModel>, ISpeciesService
    {
        public SpeciesService(ISpeciesRepository repository) : base(repository)
        {
        }
    }
}