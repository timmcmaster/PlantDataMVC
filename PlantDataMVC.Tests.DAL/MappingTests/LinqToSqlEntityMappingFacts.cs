using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using Xunit;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;

namespace PlantDataMvc3.Tests.DAL
{
    public class LinqToSqlEntityMappingFacts: IUseFixture<LinqToSqlMappingFixture>
    {
        public LinqToSqlEntityMappingFacts()
        {
        }

        public void SetFixture(LinqToSqlMappingFixture mapping)
        {
            mapping.Configure();
        }

        [Fact]
        public void TestMappingConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        //[Fact]
        //public void TestMappingConfiguration()
        //{
        //    Mapper.AssertConfigurationIsValid();
        //}
    }
}
