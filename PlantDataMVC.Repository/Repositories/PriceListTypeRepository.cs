using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class PriceListTypeRepository : EFRepository<PriceListTypeEntityModel>, IPriceListTypeRepository
    {
        public PriceListTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}