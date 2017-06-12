using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFSiteRepository : EFRepositoryBase<Site>, ISiteRepository<Site>
    {
        public EFSiteRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.SiteName));
        }
    }
}
