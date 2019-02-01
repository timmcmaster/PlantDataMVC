using PlantDataMVC.UI;
using Xunit;

namespace PlantDataMVC.Tests.UI.IoC
{
    public class ServiceFacts : IClassFixture<IocFixture>
    {
        #region Setup/Teardown
        public ServiceFacts(IocFixture fixture)
        {
            _fixture = fixture;
        }
        #endregion

        private IocFixture _fixture;

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