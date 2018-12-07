using AutoMapper;
using Xunit;

namespace PlantDataMVC.Tests.UI
{
    public class UIToDomainMappingFacts : IClassFixture<WebMappingFixture>
    {
        public UIToDomainMappingFacts()
        {
        }

        [Fact]
        public void TestMappingConfiguration()
        {
            Mapper.AssertConfigurationIsValid();
        }

    }
}
