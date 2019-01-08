using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;

namespace PlantDataMVC.WebApi.Controllers
{
    public class PlantProductTypeController : BaseApiController<PlantProductType>
    {
        public PlantProductTypeController(IPlantProductTypeDataService dataService) : base(dataService)
        {
        }
    }
}
