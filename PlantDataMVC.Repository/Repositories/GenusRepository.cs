using Framework.Domain.EF;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.UnitOfWork;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class GenusRepository : EFRepository<Genus>, IGenusRepository
    {
        private readonly IDataContextAsync _dataContext;

        public GenusRepository(IDataContextAsync dataContext, IUnitOfWorkAsync unitOfWork) : base(dataContext, unitOfWork)
        {
            _dataContext = dataContext;
        }

        public Genus GetItemByLatinName(string latinName)
        {
            return this.Queryable().FirstOrDefault(g => g.LatinName == latinName);

        }

        public Genus GetItemWithAllSpecies(int id)
        {
            return this.Query(g => g.Id == id).Include(g => g.Species).Select().SingleOrDefault();
        }
    }
}