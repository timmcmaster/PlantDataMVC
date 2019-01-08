using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantSeedSiteController : BaseApiController<PlantSeedSite>
    {
        public PlantSeedSiteController(IPlantSeedSiteDataService dataService) : base(dataService)
        {
        }
    }
}
