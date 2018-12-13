using AutoMapper;
using Framework.Service.Entities;
using Interfaces.DAL.Repository;
using Interfaces.DAL.UnitOfWork;
using Moq;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Domain.Mappers;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Service.SimpleServiceLayer;
using System;
using UnitTest.Utils.DAL;
using UnitTest.Utils.Domain;
using Xunit;
using Xunit.Abstractions;

namespace PlantDataMVC.Tests.Core
{
    public class PlantDataServiceFacts : IDisposable
    {
        private readonly ITestOutputHelper _output;

        public PlantDataServiceFacts(ITestOutputHelper output)
        {
            this._output = output;
            // Reset mapper before configuring
            Mapper.Reset();
            // Configure the mapper at start of each test
            AutoMapperCoreConfiguration.Configure();
        }

        public void Dispose()
        {
            //Mapper.Reset();
        }

        [Fact]
        public void TestCreatePlantWhereGenusLatinNameExists()
        {
            // Arrange
            // create random plant, and set expected data
            var plant = PlantBuilder.aPlant().withRandomValues()
                                             .withNoId()
                                             .Build();

            // create genus, with expected data
            var genus = GenusBuilder.aGenus().withId()
                                             .withLatinName(plant.GenericName)
                                             .Build();

            // create species, with expected data
            var species = SpeciesBuilder.aSpecies().withId()
                                                   .withGenus(genus)
                                                   .withCommonName(plant.CommonName)
                                                   .withDescription(plant.Description)
                                                   .withSpecificName(plant.SpecificName)
                                                   .withNative(plant.Native)
                                                   .withPropagationTime(plant.PropagationTime)
                                                   .Build();
            var returnSpeciesId = species.Id;
            species.Id = 0;

            var request = new CreateRequest<Plant>(plant);

            // create mocks
            var repo = new MockRepository(MockBehavior.Loose);
            var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
            var grMockWrapper = repo.Create<IRepositoryAsync<Genus>>();
            var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();
            var gqMockWrapper = repo.Create<IGenusExtensions>();

            // setup mocks with this data
            gqMockWrapper.Setup(gq => gq.GetItemByLatinName(genus.LatinName)).Returns(genus);
            GenusRepository.GenusExtensionsFactory = st => gqMockWrapper.Object;
            srMockWrapper.Setup(x => x.Add(It.IsAny<Species>())).Returns(species);
            uowMockWrapper.Setup(uow => uow.Repository<Genus>()).Returns(grMockWrapper.Object);
            uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);
            // TODO: doesn't get the outcome I hoped for (i.e. ensuring output object has Id set)
            //       This is because the output object is not this instance but a mapped copy
            //uowMockWrapper.Setup(uow => uow.SaveChanges()).Callback(() => species.Id = returnSpeciesId);


            // Act
            var target = new PlantDataService(uowMockWrapper.Object);
            var result = target.Create(request);


            // Assert
            // Verify mocks only (i.e. those setup with .Verifiable())
            //repo.Verify();

            // Verify mocks and stubs on all (regardless of Verifiable)
            repo.VerifyAll();

            // TODO: Need to verify ID on result item, but it fails because SaveChanges callback
            //       does not set the correct object. May need to be integration test instead.
            //Assert.Equal(returnSpeciesId, result.Item.Id);

            Assert.Equal(request.Item.CommonName, result.Item.CommonName);
            Assert.Equal(request.Item.Description, result.Item.Description);
            Assert.Equal(request.Item.SpecificName, result.Item.SpecificName);
            Assert.Equal(request.Item.Native, result.Item.Native);
            Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
        }

        [Fact]
        public void TestCreatePlantWhereGenusLatinNameDoesNotExist()
        {
            // Arrange
            // create random plant, and set expected data
            var plant = PlantBuilder.aPlant().withRandomValues()
                                             .withNoId()
                                             .Build();

            // create genus, with expected data
            var genus = GenusBuilder.aGenus().withId()
                                             .withLatinName(plant.GenericName)
                                             .Build();

            // create species, with expected data
            var species = SpeciesBuilder.aSpecies().withId()
                                                   .withGenus(genus)
                                                   .withCommonName(plant.CommonName)
                                                   .withDescription(plant.Description)
                                                   .withSpecificName(plant.SpecificName)
                                                   .withNative(plant.Native)
                                                   .withPropagationTime(plant.PropagationTime)
                                                   .Build();
            var returnSpeciesId = species.Id;
            species.Id = 0;

            var request = new CreateRequest<Plant>(plant);

            // create mocks
            var repo = new MockRepository(MockBehavior.Loose);
            var uowMockWrapper = repo.Create<IUnitOfWorkAsync>();
            var grMockWrapper = repo.Create<IRepositoryAsync<Genus>>();
            var srMockWrapper = repo.Create<IRepositoryAsync<Species>>();
            var gqMockWrapper = repo.Create<IGenusExtensions>();

            // setup mocks with this data
            gqMockWrapper.Setup(gq => gq.GetItemByLatinName(genus.LatinName)).Returns<Genus>(null);
            GenusRepository.GenusExtensionsFactory = st => gqMockWrapper.Object;
            grMockWrapper.Setup(x => x.Add(It.IsAny<Genus>())).Returns(genus);
            srMockWrapper.Setup(x => x.Add(It.IsAny<Species>())).Returns(species);
            uowMockWrapper.Setup(uow => uow.Repository<Genus>()).Returns(grMockWrapper.Object);
            uowMockWrapper.Setup(uow => uow.Repository<Species>()).Returns(srMockWrapper.Object);
            // TODO: doesn't get the outcome I hoped for (i.e. ensuring output object has Id set)
            //       This is because the output object is not this instance but a mapped copy
            //uowMockWrapper.Setup(uow => uow.SaveChanges()).Callback(() => species.Id = returnSpeciesId);


            // Act
            var target = new PlantDataService(uowMockWrapper.Object);
            var result = target.Create(request);


            // Assert
            // Verify mocks only (i.e. those setup with .Verifiable())
            //repo.Verify();

            // Verify mocks and stubs on all (regardless of Verifiable)
            repo.VerifyAll();

            // TODO: Need to verify ID on result item, but it fails because SaveChanges callback
            //       does not set the correct object. May need to be integration test instead.
            //Assert.Equal(returnSpeciesId, result.Item.Id);

            Assert.Equal(request.Item.CommonName, result.Item.CommonName);
            Assert.Equal(request.Item.Description, result.Item.Description);
            Assert.Equal(request.Item.SpecificName, result.Item.SpecificName);
            Assert.Equal(request.Item.Native, result.Item.Native);
            Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
        }

        /*
                [Fact]
                public void TestCreateWhereGenusLatinNameDoesNotExist()
                {
                    // Arrange
                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    var plant = DomainTestData.GenerateRandomPlant();
                    plant.Id = 0;
                    var request = new CreateRequest<Plant>(plant);

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

                    sdao.Stub(x => x.Add(species)).IgnoreArguments().Return(returnSpecies);

                    // Act
                    var target = new PlantDataService(mgr);
                    var result = target.Create(request);

                    // Assert
                    gdao.VerifyAllExpectations();
                    sdao.VerifyAllExpectations();
                    Assert.Equal(plant.CommonName, result.Item.CommonName);
                    Assert.Equal(plant.Description, result.Item.Description);
                    Assert.Equal(plant.LatinName, result.Item.LatinName);
                    Assert.Equal(plant.Native, result.Item.Native);
                    Assert.Equal(plant.PropagationTime, result.Item.PropagationTime);
                }

                [Fact]
                public void TestSelect()
                {
                    // Arrange
                    int id = 1;
                    var request = new ViewRequest<Plant>(id);

                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    var species = DALTestData.GenerateRandomSpecies();
                    species.Id = id;

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);
                    sdao.Stub(x => x.GetItemById(id)).Return(species);

                    // Act
                    var target = new PlantDataService(mgr);
                    var result = target.View(request);

                    // Assert
                    sdao.VerifyAllExpectations();
                    Assert.Equal(id, result.Item.Id);
                    Assert.Equal(species.Description, result.Item.Description);
                    Assert.Equal(species.CommonName, result.Item.CommonName);
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
                public void TestDelete()
                {
                    // Arrange
                    int id = 1;
                    var request = new DeleteRequest<Plant>(id);

                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);

                    var species = new Species();
                    sdao.Stub(x => x.GetItemById(id)).Return(species);
                    sdao.Stub(x => x.Delete(species));

                    // Act
                    var target = new PlantDataService(mgr);
                    target.Delete(request);

                    // Assert
                    sdao.VerifyAllExpectations();
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

                [Fact]
                public void TestList()
                {
                    // Arrange
                    var request = new ListRequest<Plant>();

                    var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
                    var uow = MockRepository.GenerateStub<IUnitOfWork>();
                    var gdao = MockRepository.GenerateStub<IGenusRepository>();
                    var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

                    mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
                    uow.Stub(x => x.GenusRepository).Return(gdao);
                    uow.Stub(x => x.SpeciesRepository).Return(sdao);

                    var speciesList = new List<Species>();
                    for (int i = 0; i < 10; i++)
                    {
                        speciesList.Add(DALTestData.GenerateRandomSpecies());
                    }

                    sdao.Stub(x => x.GetAll()).Return(speciesList);

                    // Act
                    var target = new PlantDataService(mgr);
                    var result = target.List(request);

                    // Assert
                    sdao.VerifyAllExpectations();
                    Assert.Equal(speciesList.Count, result.Items.Count);
                    // check order?
                }
            */
    }
}