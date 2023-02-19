using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    /// <summary>
    ///     Add custom business logic (method definitions) here
    /// </summary>
    public interface IGenusService : IService<GenusEntityModel>
    {
        GenusEntityModel GetItemByLatinName(string latinName);
        GenusEntityModel GetItemWithAllSpecies(int id);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class GenusService : Service<GenusEntityModel>, IGenusService
    {
        private readonly IGenusRepository _repository;

        public GenusService(IGenusRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public GenusEntityModel GetItemByLatinName(string latinName)
        {
            return _repository.GetItemByLatinName(latinName);
        }

        public GenusEntityModel GetItemWithAllSpecies(int id)
        {
            return _repository.GetItemWithAllSpecies(id);
        }
    }
}