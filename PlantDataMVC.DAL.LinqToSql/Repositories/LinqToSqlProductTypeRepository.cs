using System.Collections.Generic;
using System.Linq;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMVC.DAL.LinqToSql.Repositories
{
    public class LinqToSqlProductTypeRepository : LinqToSqlRepositoryBase<DAL.Entities.ProductType, LinqToSql.Entities.ProductType>, IProductTypeRepository
    {
        public LinqToSqlProductTypeRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.Name));
        }

        protected override LinqToSql.Entities.ProductType UpdateItem(LinqToSql.Entities.ProductType requestItem)
        {
            LinqToSql.Entities.ProductType dbProductType = SelectItem(requestItem.Id);

            dbProductType.Name = requestItem.Name;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
