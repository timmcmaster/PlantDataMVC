using System.Reflection;
using Common.Logging;
using Framework.Service;
using Interfaces.DAL.Repository;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;

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
        private readonly IRepositoryAsync<Genus> _repository;

        public GenusService(IRepositoryAsync<Genus> repository) : base(repository)
        {
            _repository = repository;
        }

        #region IGenusService Members
        // Not really needed, just here as an example
        public override Genus Add(Genus item)
        {
            _log.Debug(m => m("Entering {0}", MethodBase.GetCurrentMethod().Name.ToString()));
            return base.Add(item);
        }
        #endregion

        public Genus GetItemByLatinName(string latinName)
        {
            return _repository.GenusExtensions().GetItemByLatinName(latinName);
        }

        public Genus GetItemWithAllSpecies(int id)
        {
            return _repository.GenusExtensions().GetItemWithAllSpecies(id);
        }
    }
}