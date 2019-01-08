using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantSeedTrayController : BaseApiController<PlantSeedTray>
    {
        public PlantSeedTrayController(IPlantSeedTrayDataService dataService) : base(dataService)
        {
        }
    }
}
