using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Repositories
{
    public class LinqToSqlSpeciesRepository : LinqToSqlRepositoryBase<DAL.Entities.Species, LinqToSql.Entities.Species>, ISpeciesRepository
    {
        public LinqToSqlSpeciesRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.LatinName));
        }

        protected override LinqToSql.Entities.Species UpdateItem(LinqToSql.Entities.Species requestItem)
        {
            LinqToSql.Entities.Species dbSpecies = SelectItem(requestItem.Id);

            dbSpecies.GenusId = requestItem.GenusId;
            dbSpecies.LatinName = requestItem.LatinName;
            dbSpecies.CommonName = requestItem.CommonName;
            dbSpecies.Native = requestItem.Native;
            dbSpecies.PropagationTime = requestItem.PropagationTime;
            dbSpecies.Description = requestItem.Description;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
