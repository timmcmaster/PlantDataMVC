using System;
using System.Collections.Generic;
using PlantDataMVC.Domain.Entities;
using Interfaces.DAL;
using PlantDataMVC.Service.SimpleServiceLayer;
using Rhino.Mocks;
using UnitTest.Utils.TestData;
using Xunit;
using Interfaces.DAL.UnitOfWork;

namespace PlantDataMVC.Tests.Core
{
    public class PlantDataServiceFacts: IClassFixture<CoreMappingFixture>
    {
        CoreMappingFixture m_data;

        public PlantDataServiceFacts(CoreMappingFixture data)
        {
            this.m_data = data;
            this.m_data.Configure();
        }

        [Fact]
        public void TestGetGenusWhereLatinNameExists()
        {
            // Arrange
            var uow = MockRepository.GenerateStub<IUnitOfWorkAsync>();
            var gdao = MockRepository.GenerateStub<IRepositoryAsync<Genus>();
            var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

            var plant = DomainTestData.GenerateRandomPlant();

            // create genus with random Id, but set expected data
            var genus = DALTestData.GenerateRandomGenus();
            genus.LatinName = plant.GenusLatinName;

            uow.Stub(x => x.GenusRepository).Return(gdao);
            uow.Stub(x => x.SpeciesRepository).Return(sdao);
            gdao.Stub(x => x.GetItemByLatinName(genus.LatinName)).Return(genus);

            // Act
            var target = new PlantDataService(mgr);
            var result = target.GetGenus(mgr.GetUnitOfWork(), plant);

            // Assert
            Assert.NotNull(result);
            Console.WriteLine("Properties for result");
            UnitTest.Utils.Print.PrintTypeAndProperties(result);

            uow.VerifyAllExpectations();
            gdao.VerifyAllExpectations();
            sdao.VerifyAllExpectations();
            Assert.Equal(genus.Id, result.Id);
            Assert.Equal(genus.LatinName, result.LatinName);
        }

        [Fact]
        public void TestGetGenusWhereLatinNameDoesNotExist()
        {
            // Arrange
            var uow = MockRepository.GenerateStub<IUnitOfWork>();
            var gdao = MockRepository.GenerateStub<IGenusRepository>();
            var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

            var plant = DomainTestData.GenerateRandomPlant();

            var genusLatinName = plant.GenusLatinName;

            uow.Stub(x => x.GenusRepository).Return(gdao);
            uow.Stub(x => x.SpeciesRepository).Return(sdao);
            gdao.Stub(x => x.GetItemByLatinName(genusLatinName)).Return(null);

            // Act
            var target = new PlantDataService(mgr);
            var result = target.GetGenus(mgr.GetUnitOfWork(), plant);

            // Assert
            gdao.VerifyAllExpectations();
            sdao.VerifyAllExpectations();
            Assert.Null(result);
        }

        [Fact]
        public void TestCreateGenus()
        {
            // Arrange
            var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
            var uow = MockRepository.GenerateStub<IUnitOfWork>();
            var gdao = MockRepository.GenerateStub<IGenusRepository>();
            var sdao = MockRepository.GenerateStub<ISpeciesRepository>();

            var plant = DomainTestData.GenerateRandomPlant();

            // create genus with random Id, but set expected data
            var genusOut = DALTestData.GenerateRandomGenus();
            genusOut.LatinName = plant.GenusLatinName;

            var genusIn = new Genus()
                {
                    Id = 0,
                    LatinName = genusOut.LatinName
                };

            mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
            uow.Stub(x => x.GenusRepository).Return(gdao);
            uow.Stub(x => x.SpeciesRepository).Return(sdao);
            gdao.Stub(x => x.Add(genusIn)).IgnoreArguments().Return(genusOut);

            // Act
            var target = new PlantDataService(mgr);
            var result = target.CreateGenus(mgr.GetUnitOfWork(), plant);

            // Assert
            gdao.VerifyAllExpectations();
            sdao.VerifyAllExpectations();
            Assert.Equal(genusOut.Id, result.Id);
            Assert.Equal(genusOut.LatinName, result.LatinName);
        }

        [Fact]
        public void TestCreateWhereGenusLatinNameExists()
        {
            // Arrange
            var mgr = MockRepository.GenerateStub<IUnitOfWorkManager>();
            var uow = MockRepository.GenerateStub<IUnitOfWork>();
            var gdao = MockRepository.GenerateStub<IGenusRepository>();
            var sdao = MockRepository.GenerateStub<ISpeciesRepository>();
            
            var plant = DomainTestData.GenerateRandomPlant();
            plant.Id = 0;
            var request = new CreateRequest<Plant>(plant);

            // create random genus, but set expected data
            var genus = DALTestData.GenerateRandomGenus();
            genus.LatinName = plant.GenusLatinName;

            mgr.Stub(x => x.GetUnitOfWork()).Return(uow);
            uow.Stub(x => x.GenusRepository).Return(gdao);
            uow.Stub(x => x.SpeciesRepository).Return(sdao);
            gdao.Stub(x => x.GetItemByLatinName(genus.LatinName)).Return(genus);

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
            Assert.Equal(request.Item.CommonName, result.Item.CommonName);
            Assert.Equal(request.Item.Description, result.Item.Description);
            Assert.Equal(request.Item.LatinName, result.Item.LatinName);
            Assert.Equal(request.Item.Native, result.Item.Native);
            Assert.Equal(request.Item.PropagationTime, result.Item.PropagationTime);
        }

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
    }
}