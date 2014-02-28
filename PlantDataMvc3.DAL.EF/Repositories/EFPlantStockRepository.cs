using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFPlantStockRepository : EFRepositoryBase<PlantStock>, ILocalPlantStockRepository<PlantStock>
    {
        public EFPlantStockRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(ps => ps.Species.Genus.LatinName).ThenBy(ps => ps.Species.LatinName));
        }
    }
}
