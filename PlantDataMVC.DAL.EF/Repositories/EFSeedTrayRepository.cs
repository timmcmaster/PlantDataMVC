using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFSeedTrayRepository : EFRepositoryBase<SeedTray>, ISeedTrayRepository<SeedTray>
    {
        public EFSeedTrayRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.DatePlanted));
        }
    }
}
