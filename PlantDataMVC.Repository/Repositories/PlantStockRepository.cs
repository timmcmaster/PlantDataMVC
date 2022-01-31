using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using Framework.Domain.EF;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.UnitOfWork;

namespace PlantDataMVC.Repository.Repositories
{
    public class PlantStockRepository : EFRepository<PlantStock>, IPlantStockRepository
    {
        private readonly IDataContextAsync _dataContext;

        public PlantStockRepository(IDataContextAsync dataContext, IUnitOfWorkAsync unitOfWork) : base(dataContext, unitOfWork)
        {
            _dataContext = dataContext;
        }
    }
}