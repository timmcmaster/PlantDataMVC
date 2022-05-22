using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryTypeRepository : EFRepository<JournalEntryType>, IJournalEntryTypeRepository
    {
        public JournalEntryTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}