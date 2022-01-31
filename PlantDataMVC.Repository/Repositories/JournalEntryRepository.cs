using Framework.Domain.EF;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryRepository : EFRepository<JournalEntry>, IJournalEntryRepository
    {
        private readonly IDataContextAsync _dataContext;

        public JournalEntryRepository(IDataContextAsync dataContext, IUnitOfWorkAsync unitOfWork) : base(dataContext, unitOfWork)
        {
            _dataContext = dataContext;
        }

        public int GetStockCountForProduct(int plantStockId)
        {
            return this
                   .Queryable()
                   .Where(je => je.PlantStockId == plantStockId)
                   .Select(je => je.Quantity * je.JournalEntryType.Effect)
                   .Sum();
        }
    }
}