using Common.Logging;
using Framework.Service;
using Interfaces.DAL.Repository;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Service
{
    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SiteService : Service<Site>, ISiteService
    {
        private static readonly ILog _log = LogManager.GetLogger<SiteService>();

        public SiteService(IRepositoryAsync<Site> repository) : base(repository)
        {
        }
    }
}
