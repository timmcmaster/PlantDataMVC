using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using Xunit;
using PlantDataMvc3.DAL.EF.Infrastructure;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFEntityMappingFacts: IClassFixture<EFMappingFixture>
    {
        private EFMappingFixture m_mapping;

        public EFEntityMappingFacts(EFMappingFixture mapping)
        {
            m_mapping = mapping;
            m_mapping.Configure();
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
