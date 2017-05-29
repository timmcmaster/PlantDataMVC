using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFSiteRepository : EFRepositoryBase<Site>, ILocalSiteRepository<Site>
    {
        public EFSiteRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.SiteName));
        }
    }
}
