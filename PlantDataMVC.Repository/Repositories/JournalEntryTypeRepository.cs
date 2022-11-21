using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryTypeRepository : EFRepository<JournalEntryTypeEntityModel>, IJournalEntryTypeRepository
    {
        public JournalEntryTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}