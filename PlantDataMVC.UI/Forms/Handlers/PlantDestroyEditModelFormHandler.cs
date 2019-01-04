using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private IPlantDataService _dataService;

        public PlantDestroyEditModelFormHandler(IPlantDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantDestroyEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantDestroyEditModel, Plant>(form);

            //DeleteRequest<Plant> request = new DeleteRequest<Plant>(item.Id);

            IDeleteResponse<Plant> response = _dataService.Delete(item.Id);
        }
    }
}