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
        private readonly ITestOutputHelper _output;

        public DbIntegrationTests(ITestOutputHelper output)
        {
            this._output = output;
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

        [Fact]
        public async Task EmptyTest_ClearDb_Works()
        {
            _output.WriteLine("test");
        }
    }
}