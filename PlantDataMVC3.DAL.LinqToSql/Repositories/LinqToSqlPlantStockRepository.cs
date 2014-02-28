using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Repositories
{
    public class LinqToSqlPlantStockRepository : LinqToSqlRepositoryBase<DAL.Entities.PlantStock, LinqToSql.Entities.PlantStock>, IPlantStockRepository
    {
        public LinqToSqlPlantStockRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(ps => ps.Species.Genus.LatinName).ThenBy(ps => ps.Species.LatinName));
        }

        protected override LinqToSql.Entities.PlantStock UpdateItem(LinqToSql.Entities.PlantStock requestItem)
        {
            LinqToSql.Entities.PlantStock dbPlantStock = SelectItem(requestItem.Id);

            dbPlantStock.SpeciesId = requestItem.SpeciesId;
            dbPlantStock.ProductTypeId = requestItem.ProductTypeId;
            dbPlantStock.QuantityInStock = requestItem.QuantityInStock;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
