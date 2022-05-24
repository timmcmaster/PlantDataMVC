using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface ISiteService : IService<Site>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SiteService : Service<Site>, ISiteService
    {
        public SiteService(ISiteRepository repository) : base(repository)
        {
        }
    }
}