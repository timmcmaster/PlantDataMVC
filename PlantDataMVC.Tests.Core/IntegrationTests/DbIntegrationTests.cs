using System;
using System.Threading.Tasks;
using AutoMapper;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Mappers;
using PlantDataMVC.Entities.Context;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.Core.IntegrationTests
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