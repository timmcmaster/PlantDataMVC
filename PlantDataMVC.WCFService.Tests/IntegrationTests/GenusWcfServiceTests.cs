using System;
using AutoMapper;
using FluentAssertions;
using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.DTO.Mappers;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;
using PlantDataMVC.WCFService.Services;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.WCFService.Tests.IntegrationTests
{
    public class GenusWcfServiceTests : IntegrationTestBase, IDisposable
    {
        private readonly ITestOutputHelper _output;

        public GenusWcfServiceTests(ITestOutputHelper output)
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
        public void Create_UsingUnitOfWorkRepository_ReturnsIdAfterSaveChanges()
        {
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                IRepositoryAsync<Genus> genusRepository = unitOfWork.RepositoryAsync<Genus>();
                IGenusService service = new GenusService(genusRepository);

                IGenusWcfService wcfService = new GenusWcfService(unitOfWork, service);

                var requestDto = new CreateUpdateGenusDto() {LatinName = "Aaaaaaaaaaa"};

                // Act
                var createResponse = wcfService.Create(requestDto);
                var createdDto = createResponse.Item;
                var status = createResponse.Status;

                // Assert
                status.Should().Be(ServiceActionStatus.Created);
                createdDto.Should().NotBeNull();
                createdDto.Should().BeOfType<GenusDto>();
                createdDto.Id.Should().NotBe(0);
                _output.WriteLine("createdDto.Id: {0}", createdDto.Id);
            }
        }

        [Fact]
        public void Create_UsingCreatedRepository_ReturnsIdAfterSaveChanges()
        {
            using (IDataContextAsync plantDataDbContext = new PlantDataDbContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(plantDataDbContext))
            {
                // Arrange
                IRepositoryAsync<Genus> genusRepository = new Repository<Genus>(plantDataDbContext, unitOfWork);
                IGenusService service = new GenusService(genusRepository);

                IGenusWcfService wcfService = new GenusWcfService(unitOfWork, service);

                var requestDto = new CreateUpdateGenusDto() { LatinName = "Aaaaaaaaaaa" };

                // Act
                var createResponse = wcfService.Create(requestDto);
                var createdDto = createResponse.Item;
                var status = createResponse.Status;

                // Assert
                status.Should().Be(ServiceActionStatus.Created);
                createdDto.Should().NotBeNull();
                createdDto.Should().BeOfType<GenusDto>();
                createdDto.Id.Should().NotBe(0);
                _output.WriteLine("createdDto.Id: {0}", createdDto.Id);
            }
        }

        //[Fact]
        //public async Task TestCreatePlantWhereGenusLatinNameDoesNotExist()
        //{
        //    using (IDataContextAsync dataContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
        //    {
        //        // Arrange
        //        // create plant 
        //        var plant = PlantBuilder.aPlant().withNoId().Build();
        //        //var request = new CreateRequest<Plant>(plant);

        //        // Act
        //        var serviceOne = new PlantDataService(uow);
        //        var result = serviceOne.Create(plant);

        //        // Assert
        //        // verify that plant is created and species ID is set
        //        result.Item.Id.Should().NotBe(0);
        //    }
        //}

        //[Fact]
        //public async Task TestCreatePlantWhereGenusLatinNameExists()
        //{
        //    // Arrange
        //    // create first plant 
        //    var firstPlant = PlantBuilder.aPlant().withNoId().Build();

        //    // create another plant with same genus
        //    var secondPlant = PlantBuilder.aPlant().withSpecificName("curtisii").withNoId().Build();

        //    using (IDataContextAsync dataContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
        //    {
        //        // add first plant
        //        //var requestOne = new CreateRequest<Plant>(firstPlant);
        //        var serviceOne = new PlantDataService(uow);
        //        var resultOne = serviceOne.Create(firstPlant);

        //        // NOTE: within Create call, we should have called uow.SaveChanges();
        //    }

        //    using (IDataContextAsync dataContext = new PlantDataDbContext())
        //    using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
        //    {
        //        //var requestTwo = new CreateRequest<Plant>(secondPlant);

        //        // Act
        //        var target = new PlantDataService(uow);
        //        var result = target.Create(secondPlant);
        //        // NOTE: within Create call, we should have called uow.SaveChanges();

        //        // Assert
        //        // verify that plant is created and species ID is set
        //        result.Item.Id.Should().NotBe(0);
        //    }
        //}

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