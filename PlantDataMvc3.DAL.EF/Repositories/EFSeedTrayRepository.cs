using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFSeedTrayRepository : EFRepositoryBase<SeedTray>, ILocalSeedTrayRepository<SeedTray>
    {
        public EFSeedTrayRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.DatePlanted));
        }
    }
}
