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
    public class JournalEntryService : Service<JournalEntry>, IJournalEntryService
    {
        private static readonly ILog _log = LogManager.GetLogger<JournalEntryService>();

        public JournalEntryService(IRepositoryAsync<JournalEntry> repository) : base(repository)
        {
        }
    }
}
