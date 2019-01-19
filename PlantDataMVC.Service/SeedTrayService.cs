using Common.Logging;
using Framework.Service;
using Interfaces.DAL.Repository;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Service
{
    public interface ISeedTrayService : IService<SeedTray>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SeedTrayService : Service<SeedTray>, ISeedTrayService
    {
        private static readonly ILog _log = LogManager.GetLogger<SeedTrayService>();

        public SeedTrayService(IRepositoryAsync<SeedTray> repository) : base(repository)
        {
        }
    }
}
