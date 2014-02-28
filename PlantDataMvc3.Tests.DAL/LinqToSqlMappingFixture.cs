using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;

namespace PlantDataMvc3.Tests.DAL
{
    public class LinqToSqlMappingFixture
    {
        public LinqToSqlMappingFixture()
        {
        }

        public void Configure()
        {
            AutoMapperDALConfigurationLinqToSql.Configure();
        }
    }
}
