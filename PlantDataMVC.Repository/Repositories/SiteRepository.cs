using Framework.Domain.EF;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SiteRepository : EFRepository<Site>, ISiteRepository
    {
        private readonly IDataContextAsync _dataContext;

        public SiteRepository(IDataContextAsync dataContext, IUnitOfWorkAsync unitOfWork) : base(dataContext, unitOfWork)
        {
            _dataContext = dataContext;
        }
    }
}