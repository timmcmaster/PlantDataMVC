using Framework.Domain.EF;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Repository.Repositories
{
    public class SiteRepository : EFRepository<Site>, ISiteRepository
    {
        public SiteRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}