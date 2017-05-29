using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.EF.Repositories
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
