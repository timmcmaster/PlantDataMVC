using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;
using PlantDataMVC.UI;

namespace PlantDataMVC.Tests.UI.IoC
{
    public class ServiceFacts: IClassFixture<IocFixture>
    {
        IocFixture _fixture = null;

        public ServiceFacts(IocFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void IdentifyRegisteredServices()
        {
            // Arrange

            // Act
            //_fixture.container.ComponentRegistry           
            // Assert
        }

        [Fact]
        public void IdentifyTypesForServices()
        {
            // Arrange
            AutofacConfig.ConfigureContainer();

            // Act

            // Assert
        }
    }
}