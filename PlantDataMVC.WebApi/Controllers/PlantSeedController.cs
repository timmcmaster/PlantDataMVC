using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantSeedController : BaseApiController<PlantSeed>
    {
        public PlantSeedController(IPlantSeedDataService dataService) : base(dataService)
        {
        }
    }
}
