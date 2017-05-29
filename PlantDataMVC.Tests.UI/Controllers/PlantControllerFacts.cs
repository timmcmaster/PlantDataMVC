using System.Web.Mvc;
using PlantDataMVC.UI.Controllers;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.Core.SimpleServiceLayer;
using Rhino.Mocks;
using UnitTest.Utils.TestData;
using Xunit;
using System.Collections.Generic;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Helpers.ViewResults;
using PlantDataMVC.UI.Models;
using PlantDataMVC.UI.Mappers;
using System;

namespace PlantDataMVC.Tests.Controllers
{
    public class PlantControllerFacts:IClassFixture<WebMappingFixture>
    {
        WebMappingFixture m_data;

        public PlantControllerFacts(WebMappingFixture data)
        {
            this.m_data = data;
            this.m_data.Configure();
        }

        public class Index
        {
            [Fact]
            public void ReturnsViewResultOfCorrectType()
            {
                // Arrange
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var listResponse = new ListResponse<Plant>(new List<Plant>());
                plantDS.Stub(x => x.List(new ListRequest<Plant>())).IgnoreArguments().Return(listResponse);
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.Index(null, null, null, null);

                // Assert
                plantDS.VerifyAllExpectations();
                var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
                Assert.IsType(typeof(ListViewPreProcessingViewResult<PlantListViewModel>), result);
            }

            [Fact]
            public void ReturnsPlantListViewModelToTheView()
            {
                // Arrange
                var listCount = (int)17;
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var plantList = DomainTestData.GenerateRandomPlantList(listCount);
                var listResponse = new ListResponse<Plant>(plantList);
                plantDS.Stub(x => x.List(new ListRequest<Plant>())).IgnoreArguments().Return(listResponse);
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.Index(null, null, null, null);

                // Assert
                plantDS.VerifyAllExpectations();
                var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
                Assert.IsType<ListViewPreProcessingViewResult<PlantListViewModel>>(result);
                //Assert.Equal(expectedViewName, viewResult.ViewName);

                var model = viewResult.ViewData.Model;
                Assert.IsType<ListViewModel<PlantListViewModel>>(model);
            }

            [Fact]
            public void SetsViewDataWithNoModel()
            {
                //// Arrange
                //var controller = new PlantController();

                //// Act
                //var result = controller.Index();

                //// Assert
                //var viewResult = Assert.IsType<ViewResult>(result);
                //Assert.Equal("Welcome to ASP.NET MVC!", viewResult.ViewBag.Message);
                //Assert.Null(viewResult.Model);
            }
        }

        public class Show
        {
            [Fact]
            public void CanMapPlantToPlantShowViewModel()
            {
                // Arrange
                var plant = DomainTestData.GenerateRandomPlant();

                // Act
                var model = AutoMapper.Mapper.Map(plant, typeof(Plant), typeof(PlantShowViewModel));

                // Assert
                Assert.NotNull(model);
                Assert.IsType<PlantShowViewModel>(model);
                var viewModel = model as PlantShowViewModel;
                Assert.Equal(plant.Id, viewModel.Id);
                var genus = ((plant.LatinName.IndexOf(' ') == -1) ? plant.LatinName : plant.LatinName.Substring(0, plant.LatinName.IndexOf(' ')));
                var species = ((plant.LatinName.IndexOf(' ') == -1) ? "" : plant.LatinName.Substring(plant.LatinName.IndexOf(' ') + 1));
                Assert.Equal(genus, viewModel.Genus);
                Assert.Equal(species, viewModel.Species);
                Assert.Equal(plant.CommonName, viewModel.CommonName);
                Assert.Equal(plant.LatinName, viewModel.LatinName);
                Assert.Equal(plant.Description, viewModel.Description);
                Assert.Equal(plant.PropagationTime, viewModel.PropagationTime);
                Assert.Equal(plant.Native, viewModel.Native);
            }

            [Fact]
            public void PlantViewResultSucceeds()
            {
                // Arrange
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var plant = DomainTestData.GenerateRandomPlant();
                var viewRequest = new ViewRequest<Plant>(plant.Id);
                var viewResponse = new ViewResponse<Plant>(plant);
                plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.ShowBasic(plant.Id);

                // Assert
                Assert.NotNull(result);
                var viewResult = result as ViewResult;
                Assert.NotNull(viewResult);
                Assert.IsType<ViewResult>(viewResult);
                Assert.NotNull(viewResult.ViewData);
                Console.WriteLine("ViewData is not null");
                Assert.NotNull(viewResult.ViewData.Model);
                Console.WriteLine("Model is not null");
                Assert.IsType<Plant>(viewResult.ViewData.Model);
                UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData.Model);
            }

            [Fact]
            public void AutoMapViewResultSucceeds()
            {
                // Arrange
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var plant = DomainTestData.GenerateRandomPlant();
                var viewRequest = new ViewRequest<Plant>(plant.Id);
                var viewResponse = new ViewResponse<Plant>(plant);
                plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.ShowBasic(plant.Id);
                //controller.a
                
                // Assert
                Assert.NotNull(result);
                var viewResult = result as ViewResult;
                Assert.NotNull(viewResult);
                //Assert.IsType<AutoMapProcessTaskCompositeViewResult>(viewResult);
                Assert.NotNull(viewResult.ViewData);
                Console.WriteLine("ViewData is not null");
                Assert.NotNull(viewResult.ViewData.Model);
                Console.WriteLine("Model is not null");
                //Assert.IsType<PlantShowViewModel>(viewResult.ViewData.Model);
                UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData.Model);
            }

            [Fact]
            public void ReturnsPlantShowViewModelToTheView()
            {
                // Arrange
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var plant = DomainTestData.GenerateRandomPlant();
                var viewRequest = new ViewRequest<Plant>(plant.Id);
                var viewResponse = new ViewResponse<Plant>(plant);
                plantDS.Stub(x => x.View(viewRequest)).IgnoreArguments().Return(viewResponse);
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.Show(plant.Id);

                // Assert
                plantDS.VerifyAllExpectations();
                Assert.NotNull(result);
                var viewResult = result as ViewResult;
                Assert.NotNull(viewResult);
                Assert.IsType<AutoMapPreProcessingViewResult>(viewResult);
                Assert.NotNull(viewResult.ViewData);
                Console.WriteLine("ViewData is not null");
                Assert.NotNull(viewResult.ViewData.Model);
                Console.WriteLine("Model is not null");
                Assert.IsType<PlantShowViewModel>(viewResult.ViewData.Model);
            }

        }

        public class NewPlant
        {
            [Fact]
            public void ReturnsPlantNewViewModelToTheView()
            {
                // Arrange
                var plantDS = MockRepository.GenerateStub<IBasicDataService<Plant>>();
                var controller = new PlantController(plantDS);

                // Act
                var result = controller.New();

                // Assert
                plantDS.VerifyAllExpectations();
                Assert.NotNull(result);
                var viewResult = result as ViewResult;
                Assert.NotNull(viewResult);
                Assert.IsType<AutoMapPreProcessingViewResult>(viewResult);
                Assert.NotNull(viewResult.ViewData);
                Console.WriteLine("ViewData is not null");
                UnitTest.Utils.Print.PrintTypeAndProperties(viewResult.ViewData);
                Assert.NotNull(viewResult.ViewData.Model);
                Console.WriteLine("Model is not null");
                Assert.IsType<PlantNewViewModel>(viewResult.ViewData.Model);
            }

        }
    }
}