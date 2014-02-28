using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Repositories
{
    public class LinqToSqlGenusRepository : LinqToSqlRepositoryBase<DAL.Entities.Genus, LinqToSql.Entities.Genus>, IGenusRepository
    {
        public LinqToSqlGenusRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.LatinName));
        }

        public DAL.Entities.Genus GetItemByLatinName(string latinName)
        {
            LinqToSql.Entities.Genus selectedItem = SelectItem(latinName);

            DAL.Entities.Genus interfaceItem = Mapper.Map<LinqToSql.Entities.Genus, DAL.Entities.Genus>(selectedItem);

            return interfaceItem;
        }

        public LinqToSql.Entities.Genus SelectItem(string latinName)
        {
            //return this.Table.Single(p => p.LatinName == latinName);
            return this.Table.FirstOrDefault(p => p.LatinName == latinName);
        }

        protected override LinqToSql.Entities.Genus UpdateItem(LinqToSql.Entities.Genus requestItem)
        {
            LinqToSql.Entities.Genus dbGenus = SelectItem(requestItem.Id);

            dbGenus.LatinName = requestItem.LatinName;

            return requestItem;
        }
    }
}
