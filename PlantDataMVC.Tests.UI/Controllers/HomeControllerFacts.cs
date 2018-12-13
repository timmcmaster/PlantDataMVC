using FluentAssertions;
using System.Web.Mvc;
using Xunit;
using PlantDataMVC.UI.Controllers;

namespace PlantDataMVC.Tests.UI.Controllers
{
    public class HomeControllerFacts
    {
        public class Index
        {
            [Fact]
            public void ReturnsViewResultWithDefaultViewName()
            {
                // Arrange
                var controller = new HomeController();

                // Act
                var result = controller.Index();

                // Assert
                result.Should().BeAssignableTo<ActionResult>();
                result.Should().BeOfType<ViewResult>()
                        .Which.ViewName.Should().BeEmpty();
            }

            [Fact]
            public void SetsViewDataWithNoModel()
            {
                // Arrange
                var controller = new HomeController();

                // Act
                var result = controller.Index();

                // Assert
                result.Should().BeAssignableTo<ActionResult>();
                result.Should().BeOfType<ViewResult>().Which.Model.Should().BeNull();
            }
        }

        public class About
        {
            [Fact]
            public void ReturnsViewResultWithDefaultViewName()
            {
                // Arrange
                var controller = new HomeController();

                // Act
                var result = controller.About();

                // Assert
                result.Should().BeAssignableTo<ActionResult>();
                result.Should().BeOfType<ViewResult>()
                        .Which.ViewName.Should().BeEmpty();
            }

            [Fact]
            public void SetsViewDataWithNoModel()
            {
                // Arrange
                var controller = new HomeController();

                // Act
                var result = controller.About();

                // Assert
                result.Should().BeAssignableTo<ActionResult>();
                result.Should().BeOfType<ViewResult>()
                        .Which.Model.Should().BeNull();
            }
        }
    }
}