using System;
using AutoMapper;
using PlantDataMVC.Api.Models.Mappers;
using Xunit.Abstractions;

namespace PlantDataMVC.Service.Tests.UnitTests.Services
{
    public class PlantDataServiceFacts : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly MapperConfiguration _mapperConfiguration;

        public PlantDataServiceFacts(ITestOutputHelper output)
        {
            _output = output;
            // Configure the mapper at start of each test
            _mapperConfiguration = AutoMapperCoreConfiguration.Configure();
        }

        #region IDisposable Members
        public void Dispose()
        {
            //Mapper.Reset();
        }
        #endregion

        //[Fact]
        //public void TestCreatePlantWhereGenusLatinNameExists()
        //{
        //    // Arrange
        //    // create random plant, and set expected data
        //    var plant = PlantBuilder.aPlant().withRandomValues()
        //                                     .withNoId()
        //                                     .Build();

        //    // create genus, with expected data
        //    var genus = GenusBuilder.aGenus().withId()
        //                                     .withLatinName(plant.GenericName)
        //                                     .Build();

        //    // create species, with expected data
        //    var species = SpeciesBuilder.aSpecies().withId()
        //                                           .withGenus(genus)
        //                                           .withCommonName(plant.CommonName)
        //                                           .withDescription(plant.Description)
        //                                           .withSpecificName(plant.SpecificName)
        //                                           .withNative(plant.Native)
        //                                           .withPropagationTime(plant.PropagationTime)
        //                                           .Build();
        //    var returnSpeciesId = species.Id;
        //    species.Id = 0;

        //    //var request = new CreateRequest<Plant>(plant);

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
        //    var result = target.Create(plant);


        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();

        //    // TODO: Need to verify ID on result item, but it fails because SaveChanges callback
        //    //       does not set the correct object. May need to be integration test instead (or as well)
        //    //Assert.Equal(returnSpeciesId, result.Item.Id);

        //    // assertions only on limited property set at this stage
        //    result.Item.Should().BeEquivalentTo(plant, options => options
        //                                                        .Including(p => p.CommonName)
        //                                                        .Including(p => p.Description)
        //                                                        .Including(p => p.SpecificName)
        //                                                        .Including(p => p.Native)
        //                                                        .Including(p => p.PropagationTime));
        //}

        //[Fact]
        //public void TestCreatePlantWhereGenusLatinNameDoesNotExist()
        //{
        //    // Arrange
        //    // create random plant, and set expected data
        //    var plant = PlantBuilder.aPlant().withRandomValues()
        //                                     .withNoId()
        //                                     .Build();

        //    // create genus, with expected data
        //    var genus = GenusBuilder.aGenus().withId()
        //                                     .withLatinName(plant.GenericName)
        //                                     .Build();

        //    // create species, with expected data
        //    var species = SpeciesBuilder.aSpecies().withId()
        //                                           .withGenus(genus)
        //                                           .withCommonName(plant.CommonName)
        //                                           .withDescription(plant.Description)
        //                                           .withSpecificName(plant.SpecificName)
        //                                           .withNative(plant.Native)
        //                                           .withPropagationTime(plant.PropagationTime)
        //                                           .Build();
        //    var returnSpeciesId = species.Id;
        //    species.Id = 0;

        //    //var request = new CreateRequest<Plant>(plant);

        //    // create mocks
        //    var repo = new MockRepository(MockBehavior.Loose);
        //    var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
        //    var grMockWrapper = repo.Create<IRepositoryAsync<Genus>>();
        //    var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();
        //    var gqMockWrapper = repo.Create<IGenusExtensions>();

        //    // setup mocks with this data
        //    gqMockWrapper.Setup(gq => gq.GetItemByLatinName(genus.LatinName)).Returns<Genus>(null);
        //    GenusRepository.GenusExtensionsFactory = st => gqMockWrapper.Object;
        //    grMockWrapper.Setup(x => x.Add(It.IsAny<Genus>())).Returns(genus);
        //    srMockWrapper.Setup(x => x.Add(It.IsAny<Species>())).Returns(species);
        //    uowMockWrapper.Setup(uow => uow.Repository<Genus>()).Returns(grMockWrapper.Object);
        //    uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);
        //    // TODO: doesn't get the outcome I hoped for (i.e. ensuring output object has Id set)
        //    //       This is because the output object is not this instance but a mapped copy
        //    //uowMockWrapper.Setup(uow => uow.SaveChanges()).Callback(() => species.Id = returnSpeciesId);


        //    // Act
        //    var target = new PlantDataService(uowMockWrapper.Object);
        //    var result = target.Create(plant);


        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();

        //    // TODO: Need to verify ID on result item, but it fails because SaveChanges callback
        //    //       does not set the correct object. May need to be integration test instead.
        //    //Assert.Equal(returnSpeciesId, result.Item.Id);

        //    // assertions only on limited property set at this stage
        //    result.Item.Should().BeEquivalentTo(plant, options => options
        //                                                        .Including(p => p.CommonName)
        //                                                        .Including(p => p.Description)
        //                                                        .Including(p => p.SpecificName)
        //                                                        .Including(p => p.Native)
        //                                                        .Including(p => p.PropagationTime));
        //}

        //[Fact]
        //public void TestSelect()
        //{
        //    // Arrange
        //    int plantId = 1; // will be same as species Id

        //    // create genus, with expected data
        //    var genus = GenusBuilder.aGenus().withRandomValues().withId().Build();

        //    // create species, with expected data
        //    var species = SpeciesBuilder.aSpecies().withRandomValues().withGenus(genus).withNoId().Build();
        //    species.Id = plantId;

        //    //var request = new ViewRequest<Plant>(plantId);

        //    // create mocks
        //    var repo = new MockRepository(MockBehavior.Loose);
        //    var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
        //    var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();

        //    // setup mocks with this data
        //    srMockWrapper.Setup(x => x.GetItemById(plantId)).Returns(species);
        //    uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);


        //    // Act
        //    var target = new PlantDataService(uowMockWrapper.Object);
        //    var result = target.View(plantId);


        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();

        //    // assertions only on limited property set at this stage
        //    result.Item.Should().BeEquivalentTo(species, options => options
        //                                                        .Including(p => p.Id)
        //                                                        .Including(p => p.CommonName)
        //                                                        .Including(p => p.Description)
        //                                                        .Including(p => p.SpecificName)
        //                                                        .Including(p => p.Native)
        //                                                        .Including(p => p.PropagationTime));
        //}

        //[Fact]
        //public void TestList()
        //{
        //    // Arrange
        //    var speciesList = new List<Species>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var genus = GenusBuilder.aGenus().withRandomValues().withId().Build();
        //        var species = SpeciesBuilder.aSpecies().withRandomValues().withGenus(genus).withId().Build();

        //        speciesList.Add(species);
        //    }

        //    //var request = new ListRequest<Plant>();


        //    // create mocks
        //    var repo = new MockRepository(MockBehavior.Loose);
        //    var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
        //    var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();

        //    // setup mocks with this data
        //    srMockWrapper.Setup(x => x.GetAll()).Returns(speciesList);
        //    uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);

        //    // Act
        //    var target = new PlantDataService(uowMockWrapper.Object);
        //    var result = target.List();

        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();

        //    // Just check count at this stage
        //    result.Items.Count.Should().Be(speciesList.Count);
        //    // TODO: add more stringent expectations 

        //    // check order?
        //}

        //[Fact]
        //public void TestDelete()
        //{
        //    // Arrange
        //    // create genus, with expected data
        //    var genus = GenusBuilder.aGenus().withId().Build();

        //    // create species, with expected data
        //    var species = SpeciesBuilder.aSpecies().withGenus(genus).withId().Build();

        //    //var request = new DeleteRequest<Plant>(species.Id);

        //    // create mocks
        //    var repo = new MockRepository(MockBehavior.Loose);
        //    var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
        //    var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();

        //    // setup mocks with this data
        //    srMockWrapper.Setup(x => x.GetItemById(species.Id)).Returns(species);
        //    srMockWrapper.Setup(x => x.Delete(species));
        //    uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);

        //    // Act
        //    var target = new PlantDataService(uowMockWrapper.Object);
        //    target.Delete(species.Id);

        //    // Assert
        //    // Verify mocks only (i.e. those setup with .Verifiable())
        //    //repo.Verify();

        //    // Verify mocks and stubs on all (regardless of Verifiable)
        //    repo.VerifyAll();
        //}

        /*
        [Fact]
        public void TestInvalidDelete()
        {
            // Arrange
            int id = 0;

            var species = new Species();
            species.Id = id;

            var request = new DeleteRequest<Plant>(species.Id);

            // create mocks
            var repo = new MockRepository(MockBehavior.Loose);
            var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
            var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();

            // setup mocks with this data
            srMockWrapper.Setup(x => x.GetItemById(species.Id)).Returns(species);
            srMockWrapper.Setup(x => x.Delete(species));
            uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);

            // Act
            try
            {
                var target = new PlantDataService(uowMockWrapper.Object);
                target.Delete(request);

                // Assert
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Assert.NotNull(ex);
                Assert.Equal("id", ex.ParamName);
                //dont throw cos its expected
            }

            // Assert
            // Verify mocks only (i.e. those setup with .Verifiable())
            //repo.Verify();

            // Verify mocks and stubs on all (regardless of Verifiable)
            repo.VerifyAll();
        }



                [Fact]
                public void TestUpdateWhereGenusLatinNameDoesNotExist()
                {
                    // Arrange
                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    var plant = DomainTestData.GenerateRandomPlant();
                    var request = new UpdateRequest<Plant>(plant);

                    var genus = new Genus()
                    {
                        Id = 0,
                        LatinName = plant.GenusLatinName
                    };

                    // create random genus, but set expected data
                    var returnGenus = DALTestData.GenerateRandomGenus();
                    returnGenus.LatinName = genus.LatinName;

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);
                    gdao.Stub(x => x.GetItemByLatinName(genus.LatinName)).Return(null);
                    gdao.Stub(x => x.Add(genus)).IgnoreArguments().Return(returnGenus);

                    // create random species, but set expected data
                    var species = DALTestData.GenerateRandomSpecies();
                    species.Id = plant.Id;
                    species.CommonName = plant.CommonName;
                    species.Description = plant.Description;
                    species.LatinName = plant.SpeciesLatinName;
                    species.Native = plant.Native;
                    species.PropagationTime = plant.PropagationTime;

                    var returnSpecies = new Species()
                    {
                        GenusId = returnGenus.Id,
                        GenusLatinName = returnGenus.LatinName,
                        Id = species.Id,
                        CommonName = species.CommonName,
                        Description = species.Description,
                        LatinName = species.LatinName,
                        Native = species.Native,
                        PropagationTime = species.PropagationTime
                    };

                    sdao.Stub(x => x.Save(species)).IgnoreArguments().Return(returnSpecies);

                    // Act
                    var target = new PlantDataService(mgr);
                    var result = target.Update(request);

                    // Assert
                    gdao.VerifyAllExpectations();
                    sdao.VerifyAllExpectations();
                    Assert.Equal(request.Item.Id, result.Item.Id);
                    Assert.Equal(request.Item.CommonName, result.Item.CommonName);
                    Assert.Equal(request.Item.Description, result.Item.Description);
                    Assert.Equal(request.Item.LatinName, result.Item.LatinName);
                    Assert.Equal(request.Item.Native, result.Item.Native);
                    Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
                }

                [Fact]
                public void TestUpdateWhereGenusLatinNameExists()
                {
                    // Arrange
                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    var plant = DomainTestData.GenerateRandomPlant();
                    var request = new UpdateRequest<Plant>(plant);

                    // create random genus, but set expected data
                    var genus = DALTestData.GenerateRandomGenus();
                    genus.LatinName = plant.GenusLatinName;

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);
                    gdao.Stub(x => x.GetItemByLatinName(genus.LatinName)).Return(genus);

                    // create random species, but set expected data
                    var species = DALTestData.GenerateRandomSpecies();
                    species.Id = plant.Id;
                    species.CommonName = plant.CommonName;
                    species.Description = plant.Description;
                    species.LatinName = plant.SpeciesLatinName;
                    species.Native = plant.Native;
                    species.PropagationTime = plant.PropagationTime;

                    var returnSpecies = new Species()
                    {
                        GenusId = genus.Id,
                        GenusLatinName = genus.LatinName,
                        Id = species.Id,
                        CommonName = species.CommonName,
                        Description = species.Description,
                        LatinName = species.LatinName,
                        Native = species.Native,
                        PropagationTime = species.PropagationTime
                    };

                    sdao.Stub(x => x.Save(species)).IgnoreArguments().Return(returnSpecies);

                    // Act
                    var target = new PlantDataService(mgr);
                    var result = target.Update(request);

                    // Assert
                    gdao.VerifyAllExpectations();
                    sdao.VerifyAllExpectations();
                    Assert.Equal(request.Item.Id, result.Item.Id);
                    Assert.Equal(request.Item.CommonName, result.Item.CommonName);
                    Assert.Equal(request.Item.Description, result.Item.Description);
                    Assert.Equal(request.Item.LatinName, result.Item.LatinName);
                    Assert.Equal(request.Item.Native, result.Item.Native);
                    Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
                }


                [Fact]
                public void TestInvalidDelete()
                {
                    // Arrange
                    int id = 0;
                    var request = new DeleteRequest<Plant>(id);

                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);
                    // Act
                    try
                    {
                        var target = new PlantDataService(mgr);
                        target.Delete(request);

                        // Assert
                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        Assert.NotNull(ex);
                        Assert.Equal("id", ex.ParamName);
                        //dont throw cos its expected
                    }

                }

            */
    }
}