using System;
using AutoMapper;
using PlantDataMVC.UI.Mappers;
using Xunit;

namespace PlantDataMVC.UI.Tests.Automapper
{
    public class UiToDomainMappingFacts : IDisposable
    {
        #region Setup/Teardown
        public UiToDomainMappingFacts()
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
        #endregion

        [Fact]
        public void TestMappingConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}