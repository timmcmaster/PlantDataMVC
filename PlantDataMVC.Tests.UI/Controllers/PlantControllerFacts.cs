using AutoMapper;
using FluentAssertions;
using Framework.WcfService.Responses;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Moq;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Mappers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.WCFService.ServiceContracts;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace PlantDataMVC.Tests.UI.Controllers
{
    public class PlantControllerFacts
    {
        public PlantControllerFacts()
        {
            // Reset Mapper before configuring
            Mapper.Reset();
            // Configure mapping at start of each test
            AutoMapperBootstrapper.Initialize();
        }

        public class Index
        {
            [Fact]
            public void ReturnsViewResultOfCorrectType()
            {
                // Arrange
                var listResponse = new ListResponse<SpeciesInListDto>(new List<SpeciesInListDto>(),ServiceActionStatus.Ok);

                // create mocks
                var repo = new MockRepository(MockBehavior.Loose);
                var dsMockWrapper = repo.Create<ISpeciesWcfService>();
                var fhfMockWrapper = repo.Create<IFormHandlerFactory>();

                dsMockWrapper.Setup(x => x.List()).Returns(listResponse);

                var controller = new PlantController(dsMockWrapper.Object, fhfMockWrapper.Object);

                // Act
                var result = controller.Index(null, null, null, null);

                // Assert
                // Verify mocks only (i.e. those setup with .Verifiable())
                //repo.Verify();

                // Verify mocks and stubs on all (regardless of Verifiable)
                repo.VerifyAll();

                result.Should().BeAssignableTo<ViewResult>()
                    .Which.Should().BeOfType<ListViewPreProcessingViewResult<PlantListViewModel>>();
            }

            [Fact]
            public void ReturnsPlantListViewModelToTheView()
            {
                // Arrange
                int listCount = 17;
                var speciesList = new List<SpeciesInListDto>();
                for (int i = 0; i < listCount; i++)
                {
                    speciesList.Add(new SpeciesInListDto() { Id = i, GenusId = i, SpecificName = "species" + i, CommonName = "Common name of species" + i});
                }
                var listResponse = new ListResponse<SpeciesInListDto>(speciesList, ServiceActionStatus.Ok);
                
                // create mocks
                var repo = new MockRepository(MockBehavior.Loose);
                var dsMockWrapper = repo.Create<ISpeciesWcfService>();
                var fhfMockWrapper = repo.Create<IFormHandlerFactory>();

                dsMockWrapper.Setup(x => x.List()).Returns(listResponse);

                var controller = new PlantController(dsMockWrapper.Object, fhfMockWrapper.Object);

                // Act
                var result = controller.Index(null, null, null, null);

                // Assert
                // Verify mocks only (i.e. those setup with .Verifiable())
                //repo.Verify();

                // Verify mocks and stubs on all (regardless of Verifiable)
                repo.VerifyAll();

                result.Should().BeAssignableTo<ViewResult>()
                    .Which.Should().BeOfType<ListViewPreProcessingViewResult<PlantListViewModel>>();

                // TODO: need to set up form handler factory mock to get view model correctly
                //result.Should().BeAssignableTo<ViewResult>()
                //    .Which.ViewData.Model.Should().BeOfType<ListViewModel<PlantListViewModel>>();
            }
        }

        public class Show
        {
            //[Fact]
            //public void CanMapPlantToPlantShowViewModel()
            //{
            //    // Arrange
            //    var plant = DomainTestData.GenerateRandomPlant();

            //    // Act
            //    var model = AutoMapper.Mapper.Map(plant, typeof(Plant), typeof(PlantShowViewModel));

            //    // Assert
            //    Assert.NotNull(model);
            //    Assert.IsType<PlantShowViewModel>(model);
            //    var viewModel = model as PlantShowViewModel;
            //    Assert.Equal(plant.Id, viewModel.Id);
            //    var genus = ((plant.LatinName.IndexOf(' ') == -1) ? plant.LatinName : plant.LatinName.Substring(0, plant.LatinName.IndexOf(' ')));
            //    var species = ((plant.LatinName.IndexOf(' ') == -1) ? "" : plant.LatinName.Substring(plant.LatinName.IndexOf(' ') + 1));
            //    Assert.Equal(genus, viewModel.Genus);
            //    Assert.Equal(species, viewModel.Species);
            //    Assert.Equal(plant.CommonName, viewModel.CommonName);
            //    Assert.Equal(plant.LatinName, viewModel.LatinName);
            //    Assert.Equal(plant.Description, viewModel.Description);
            //    Assert.Equal(plant.PropagationTime, viewModel.PropagationTime);
            //    Assert.Equal(plant.Native, viewModel.Native);
            //}

            //[Fact]
            //public void PlantViewResultSucceeds()
            //{
            //    // Arrange
            //    var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
            //    var plant = DomainTestData.GenerateRandomPlant();
            //    var viewRequest = new ViewRequest<Plant>(plant.Id);
            //    var viewResponse = new ViewResponse<Plant>(plant);
            //    plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
            //    var controller = new PlantController(plantDS);

            //    // Act
            //    var result = controller.ShowBasic(plant.Id);

            //    // Assert
            //    Assert.NotNull(result);
            //    var viewResult = result as ViewResult;
            //    Assert.NotNull(viewResult);
            //    Assert.IsType<ViewResult>(viewResult);
            //    Assert.NotNull(viewResult.ViewData);
            //    Console.WriteLine("ViewData is not null");
            //    Assert.NotNull(viewResult.ViewData.Model);
            //    Console.WriteLine("Model is not null");
            //    Assert.IsType<Plant>(viewResult.ViewData.Model);
            //    UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData.Model);
            //}

            //[Fact]
            //public void AutoMapViewResultSucceeds()
            //{
            //    // Arrange
            //    var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
            //    var plant = DomainTestData.GenerateRandomPlant();
            //    var viewRequest = new ViewRequest<Plant>(plant.Id);
            //    var viewResponse = new ViewResponse<Plant>(plant);
            //    plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
            //    var controller = new PlantController(plantDS);

            //    // Act
            //    var result = controller.ShowBasic(plant.Id);
            //    //controller.a

            //    // Assert
            //    Assert.NotNull(result);
            //    var viewResult = result as ViewResult;
            //    Assert.NotNull(viewResult);
            //    //Assert.IsType<AutoMapProcessTaskCompositeViewResult>(viewResult);
            //    Assert.NotNull(viewResult.ViewData);
            //    Console.WriteLine("ViewData is not null");
            //    Assert.NotNull(viewResult.ViewData.Model);
            //    Console.WriteLine("Model is not null");
            //    //Assert.IsType<PlantShowViewModel>(viewResult.ViewData.Model);
            //    UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData.Model);
            //}

            //[Fact]
            //public void ReturnsPlantShowViewModelToTheView()
            //{
            //    // Arrange
            //    var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
            //    var plant = DomainTestData.GenerateRandomPlant();
            //    var viewRequest = new ViewRequest<Plant>(plant.Id);
            //    var viewResponse = new ViewResponse<Plant>(plant);
            //    plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
            //    var controller = new PlantController(plantDS);

            //    // Act
            //    var result = controller.Show(plant.Id);

            //    // Assert
            //    plantDS.VerifyAllExpectations();
            //    Assert.NotNull(result);
            //    var viewResult = result as ViewResult;
            //    Assert.NotNull(viewResult);
            //    Assert.IsType<AutoMapPreProcessingViewResult>(viewResult);
            //    Assert.NotNull(viewResult.ViewData);
            //    Console.WriteLine("ViewData is not null");
            //    Assert.NotNull(viewResult.ViewData.Model);
            //    Console.WriteLine("Model is not null");
            //    Assert.IsType<PlantShowViewModel>(viewResult.ViewData.Model);
            //}
        }

        public class NewPlant
        {
            //[Fact]
            //public void ReturnsPlantNewViewModelToTheView()
            //{
            //    // Arrange
            //    var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
            //    var controller = new PlantController(plantDS);

            //    // Act
            //    var result = controller.New();

            //    // Assert
            //    plantDS.VerifyAllExpectations();
            //    Assert.NotNull(result);
            //    var viewResult = result as ViewResult;
            //    Assert.NotNull(viewResult);
            //    Assert.IsType<AutoMapPreProcessingViewResult>(viewResult);
            //    Assert.NotNull(viewResult.ViewData);
            //    Console.WriteLine("ViewData is not null");
            //    UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData);
            //    Assert.NotNull(viewResult.ViewData.Model);
            //    Console.WriteLine("Model is not null");
            //    Assert.IsType<PlantNewViewModel>(viewResult.ViewData.Model);
            //}
        }
    }
}