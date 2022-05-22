using Common.Logging;
using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface IJournalEntryTypeService : IService<JournalEntryType>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class JournalEntryTypeService : Service<JournalEntryType>, IJournalEntryTypeService
    {
        private static readonly ILog _log = LogManager.GetLogger<JournalEntryTypeService>();

        public JournalEntryTypeService(IJournalEntryTypeRepository repository) : base(repository)
        {
        }
    }
}