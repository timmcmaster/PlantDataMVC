using Common.Logging;
using Framework.Service;
using Interfaces.Domain.Repository;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;

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

        public JournalEntryTypeService(IRepositoryAsync<JournalEntryType> repository) : base(repository)
        {
        }
    }
}