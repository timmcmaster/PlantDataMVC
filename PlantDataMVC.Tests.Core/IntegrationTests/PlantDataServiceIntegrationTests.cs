using Framework.DAL.EF;
using Interfaces.DAL.DataContext;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Entities.Context;
using PlantDataMVC.Entities.Models;
using UnitTest.Utils.DAL;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.Core
{
    public class PlantDataServiceIntegrationTests : IClassFixture<CoreMappingFixture>
    {
        private readonly ITestOutputHelper _output;

        public PlantDataServiceIntegrationTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestCreatePlantWhereGenusLatinNameExists()
        {
            // TODO: Check if fake has same response as real (i.e. creates IDs on savechanges)

            using (IDataContextAsync dataContext = new FakePlantDataDbContext())
            using (IUnitOfWorkAsync uow = new UnitOfWork(dataContext))
            {
                // Arrange
                // Create genus data
                var genus = GenusBuilder.aGenus().withRandomValues().withId().Build();

                // Add genus via repository to ensure it exists in DB
                uow.Repository<Genus>().Add(genus);
                uow.SaveChanges();

                // create a plant with a genus that exists, but species does not


                // Act
                //var target = new PlantDataService(uow);
                //var result = target.Create(request);


                // Assert
                // verify that plant is created and species ID is set

                // clean up data to restore DB state
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