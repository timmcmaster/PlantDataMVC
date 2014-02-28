﻿using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Repositories
{
    public class LinqToSqlSiteRepository : LinqToSqlRepositoryBase<DAL.Entities.Site, LinqToSql.Entities.Site>, ISiteRepository
    {
        public LinqToSqlSiteRepository(DataContext context)
            : base(context)
        {
            this.DefaultOrderBy = (q => q.OrderBy(s => s.SiteName));
        }

        protected override LinqToSql.Entities.Site UpdateItem(LinqToSql.Entities.Site requestItem)
        {
            LinqToSql.Entities.Site dbSite = SelectItem(requestItem.Id);

            dbSite.Latitude = requestItem.Latitude;
            dbSite.Longitude = requestItem.Longitude;
            dbSite.SiteName = requestItem.SiteName;
            dbSite.Suburb = requestItem.Suburb;

            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }
    }
}
