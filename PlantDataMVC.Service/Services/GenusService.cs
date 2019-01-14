using Common.Logging;
using Framework.Service;
using Interfaces.DAL.Repository;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Service
{
    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class GenusService : Service<Genus>, IGenusService
    {
        #region Private variables
        private static readonly ILog _log = LogManager.GetLogger<GenusService>();
        private readonly IRepositoryAsync<Genus> _repository;
        #endregion

        public GenusService(IRepositoryAsync<Genus> repository) : base(repository)
        {
            _repository = repository;
        }

        #region Service overrides
        // Not really needed, just here as an example
        public override Genus Add(Genus item)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));
            return base.Add(item);
        }
        #endregion

        #region Repository custom methods
        public Genus GetItemWithAllSpecies(int id)
        {
            return _repository.GenusExtensions().GetItemWithAllSpecies(id);
        }
       
        #endregion
    }
}
