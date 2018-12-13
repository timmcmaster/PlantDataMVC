using AutoMapper;
using PlantDataMVC.UI.Mappers;
using System;
using Xunit;

namespace PlantDataMVC.Tests.UI
{
    public class UIToDomainMappingFacts : IDisposable
    {
        public UIToDomainMappingFacts()
        {
            // Reset Mapper before configuring
            Mapper.Reset();
            // Configure mapping at start of each test
            AutoMapperBootstrapper.Initialize();

            // or?
            //AutoMapperWebConfiguration.Configure();
        }

        public void Dispose()
        {
            //Mapper.Reset();
        }

        [Fact]
        public void TestMappingConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

    }
}
