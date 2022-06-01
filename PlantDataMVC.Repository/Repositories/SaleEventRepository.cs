using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SaleEventRepository : EFRepository<SaleEvent>, ISaleEventRepository
    {
        public SaleEventRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}