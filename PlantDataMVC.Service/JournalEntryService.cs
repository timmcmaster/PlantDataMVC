using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface IJournalEntryService : IService<JournalEntryEntityModel>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class JournalEntryService : Service<JournalEntryEntityModel>, IJournalEntryService
    {
        public JournalEntryService(IJournalEntryRepository repository) : base(repository)
        {
        }
    }
}