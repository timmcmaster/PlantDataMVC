using Common.Logging;
using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface ISpeciesService : IService<Species>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SpeciesService : Service<Species>, ISpeciesService
    {
        private static readonly ILog _log = LogManager.GetLogger<SpeciesService>();

        public SpeciesService(ISpeciesRepository repository) : base(repository)
        {
        }
    }
}