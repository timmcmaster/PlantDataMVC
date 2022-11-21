using Framework.Domain.EF;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SiteRepository : EFRepository<SiteEntityModel>, ISiteRepository
    {
        public SiteRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}