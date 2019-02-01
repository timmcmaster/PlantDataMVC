using System;
using System.Threading.Tasks;
using AutoMapper;
using PlantDataMVC.DTO.Mappers;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.WCFService.Tests.IntegrationTests
{
    public class DbIntegrationTests : IntegrationTestBase, IDisposable
    {
        #region Setup/Teardown
        public DbIntegrationTests(ITestOutputHelper output)
        {
            _output = output;
            // Reset Mapper at end of each test
            Mapper.Reset();
            // Configure the mapper at start of each test
            AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset Mapper at end of each test
            //Mapper.Reset();
        }
        #endregion

        private readonly ITestOutputHelper _output;

        [Fact]
        public async Task EmptyTest_ClearDb_Works()
        {
            _output.WriteLine("test");
        }
    }
}