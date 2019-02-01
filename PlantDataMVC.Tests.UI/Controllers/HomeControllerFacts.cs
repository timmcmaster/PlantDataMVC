using System.Web.Mvc;
using FluentAssertions;
using PlantDataMVC.UI.Controllers;
using Xunit;

namespace PlantDataMVC.Tests.UI.Controllers
{
    public class HomeControllerFacts
    {
        #region Nested type: About
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
        #endregion

        #region Nested type: Index
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
        #endregion
    }
}