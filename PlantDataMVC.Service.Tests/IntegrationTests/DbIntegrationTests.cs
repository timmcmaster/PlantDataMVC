using System;
using System.Threading.Tasks;
using AutoMapper;
using PlantDataMVC.DTO.Mappers;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Service.Tests.IntegrationTests
{
    public class DbIntegrationTests : IntegrationTestBase, IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly MapperConfiguration _mapperConfiguration;

        #region Setup/Teardown
        public DbIntegrationTests(ITestOutputHelper output, DbFixture dbFixture) : base(dbFixture)
        {
            _output = output;
            // Configure the mapper at start of each test
            _mapperConfiguration = AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            // Reset Mapper at end of each test
            //Mapper.Reset();
        }
        #endregion

        [Fact]
        public async Task EmptyTest_ClearDb_Works()
        {
            _output.WriteLine("test");
        }
    }
}