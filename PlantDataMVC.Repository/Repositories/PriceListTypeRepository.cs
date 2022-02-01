using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class PriceListTypeRepository : EFRepository<PriceListType>, IPriceListTypeRepository
    {
        private readonly IDbContext _dbContext;

        public PriceListTypeRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}