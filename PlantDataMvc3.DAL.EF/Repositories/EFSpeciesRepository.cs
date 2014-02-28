﻿using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    public class EFSpeciesRepository : EFRepositoryBase<Species>, ILocalSpeciesRepository<Species>
    {
        public EFSpeciesRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(s => s.LatinName));
        }

        //protected override IList<EF.Entities.Species> ListItems(Expression<Func<IQueryable<EF.Entities.Species>, IOrderedQueryable<EF.Entities.Species>>> orderBy = null, List<string> includeProperties = null)
        //{
        //    // Ensure Genus is in include properties
        //    if (includeProperties == null)
        //    {
        //        includeProperties = new List<string>();
        //    }

        //    if (!includeProperties.Contains("Genus"))
        //    {
        //        includeProperties.Add("Genus");
        //    }

        //    return base.ListItems(orderBy, includeProperties);
        //}
    }
}
