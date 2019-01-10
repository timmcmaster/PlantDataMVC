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
    public class GenusService : Service<Genus>, IGenusService
    {
        private static readonly ILog _log = LogManager.GetLogger<GenusService>();

        public GenusService(IRepositoryAsync<Genus> repository) : base(repository)
        {
        }

        #region Service overrides
        // Not really needed, just here as an example
        public override Genus Add(Genus item)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));
            return base.Add(item);
        }
        #endregion

    }
}
