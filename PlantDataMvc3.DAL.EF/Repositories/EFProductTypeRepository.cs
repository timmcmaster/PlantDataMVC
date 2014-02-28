using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFProductTypeRepository : EFRepositoryBase<ProductType>, ILocalProductTypeRepository<ProductType>
    {
        public EFProductTypeRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(pt => pt.Name));
        }
    }
}
