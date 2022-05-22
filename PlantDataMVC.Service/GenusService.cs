using Common.Logging;
using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    /// <summary>
    ///     Add custom business logic (method definitions) here
    /// </summary>
    public interface IGenusService : IService<Genus>
    {
        Genus GetItemByLatinName(string latinName);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class GenusService : Service<Genus>, IGenusService
    {
        private static readonly ILog _log = LogManager.GetLogger<GenusService>();
        private readonly IGenusRepository _repository;

        public GenusService(IGenusRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Genus GetItemByLatinName(string latinName)
        {
            return _repository.GetItemByLatinName(latinName);
        }

        public Genus GetItemWithAllSpecies(int id)
        {
            return _repository.GetItemWithAllSpecies(id);
        }
    }
}