using Interfaces.DTO;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.WebApi.Helpers;
using Xunit;

namespace PlantDataMVC.WebApi.Tests.UnitTests
{
    public class HelperTests
    {
        [Fact]
        public void TestGetRelatedObjects()
        {
            var relatedObjs = DataShaping.GetRelatedDtoObjects(new SpeciesDto());
        }

    }
}