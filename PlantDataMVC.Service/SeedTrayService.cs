using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface ISeedTrayService : IService<SeedTrayEntityModel>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SeedTrayService : Service<SeedTrayEntityModel>, ISeedTrayService
    {
        public SeedTrayService(ISeedTrayRepository repository) : base(repository)
        {
        }
    }
}