using AutoMapper;
using Framework.DAL.EF;
using Framework.Service.Entities;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Domain.Mappers;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Service.SimpleServiceLayer;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using UnitTest.Utils.Domain;
using Xunit;
using Xunit.Abstractions;


namespace PlantDataMVC.Tests.Core
{
    public class PlantDataServiceIntegrationTests : IntegrationTestBase, IDisposable
    {
        private readonly ITestOutputHelper _output;

        public PlantDataServiceIntegrationTests(ITestOutputHelper output)
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
        public async Task TestClearDB()
        {
            _output.WriteLine("test");
        }

        [Fact]
        public async Task TestCreatePlantWhereGenusLatinNameDoesNotExist()
        {
            using (IDataContextAsync dataContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
            {
                // Arrange
                // create plant 
                var plant = PlantBuilder.aPlant().withNoId().Build();
                //var request = new CreateRequest<Plant>(plant);

                // Act
                var serviceOne = new PlantDataService(uow);
                var result = serviceOne.Create(plant);

                // Assert
                // verify that plant is created and species ID is set
                result.Item.Id.Should().NotBe(0);
            }
        }

        [Fact]
        public async Task TestCreatePlantWhereGenusLatinNameExists()
        {
            // Arrange
            // create first plant 
            var firstPlant = PlantBuilder.aPlant().withNoId().Build();

            // create another plant with same genus
            var secondPlant = PlantBuilder.aPlant().withSpecificName("curtisii").withNoId().Build();

            using (IDataContextAsync dataContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
            {
                // add first plant
                //var requestOne = new CreateRequest<Plant>(firstPlant);
                var serviceOne = new PlantDataService(uow);
                var resultOne = serviceOne.Create(firstPlant);

                // NOTE: within Create call, we should have called uow.SaveChanges();
            }

            using (IDataContextAsync dataContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
            {
                //var requestTwo = new CreateRequest<Plant>(secondPlant);

                // Act
                var target = new PlantDataService(uow);
                var result = target.Create(secondPlant);
                // NOTE: within Create call, we should have called uow.SaveChanges();

                // Assert
                // verify that plant is created and species ID is set
                result.Item.Id.Should().NotBe(0);
            }
        }

        //[Fact]
        //public void TestCreatePlantWhereGenusLatinNameExists()
        //{
        //    // Arrange
        //    // create random plant, and set expected data
        //    var plant = DomainTestData.GenerateRandomPlant();
        //    plant.Id = 0;

        //    // create random genus, but set expected data
        //    var genus = DALTestData.GenerateRandomGenus();
        //    genus.LatinName = plant.GenericName;

        //    // create random species, but set expected data
        //    var species = DALTestData.GenerateRandomSpecies();
        //    var returnSpeciesId = species.Id;
        //    species.Id = 0;
        //    species.Genus = genus;
        //    species.GenusId = genus.Id;
        //    species.CommonName = plant.CommonName;
        //    species.Description = plant.Description;
        //    species.SpecificName = plant.SpecificName;
        //    species.Native = plant.Native;
        //    species.PropagationTime = plant.PropagationTime;

        //    var request = new CreateRequest<Plant>(plant);

        //    // create mocks
        //    var repo = new MockRepository(MockBehavior.Loose);
        //    var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
        //    var grMockWrapper = repo.Create<IRepositoryAsync<Genus>>();
        //    var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();
        //    var gqMockWrapper = repo.Create<IGenusExtensions>();

        //    // setup mocks with this data
        //    gqMockWrapper.Setup(gq => gq.GetItemByLatinName(genus.LatinName)).Returns(genus);
        //    GenusRepository.GenusExtensionsFactory = st => gqMockWrapper.Object;
        //    srMockWrapper.Setup(x => x.Add(It.IsAny<Species>())).Returns(species);
        //    uowMockWrapper.Setup(uow => uow.Repository<Genus>()).Returns(grMockWrapper.Object);
        //    uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);
        //    // TODO: doesn't get the outcome I hoped for (i.e. ensuring output object has Id set)
        //    //       This is because the output object is not this instance but a mapped copy
        //    //uowMockWrapper.Setup(uow => uow.SaveChanges()).Callback(() => species.Id = returnSpeciesId);


        //    // Act
        //    var target = new PlantDataService(uowMockWrapper.Object);
        //    var result = target.Create(request);


        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();

        //    // TODO: Need to verify ID on result item, but it fails because SaveChanges callback
        //    //       does not set the correct object. May need to be integration test instead.
        //    //Assert.Equal(returnSpeciesId, result.Item.Id);

        //    Assert.Equal(request.Item.CommonName, result.Item.CommonName);
        //    Assert.Equal(request.Item.Description, result.Item.Description);
        //    Assert.Equal(request.Item.SpecificName, result.Item.SpecificName);
        //    Assert.Equal(request.Item.Native, result.Item.Native);
        //    Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
        //}
    }
}