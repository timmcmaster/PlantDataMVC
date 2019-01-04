using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantCreateEditModelFormHandler : IFormHandler<PlantCreateEditModel>
    {
        private IPlantDataService _dataService;

        public PlantCreateEditModelFormHandler(IPlantDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantCreateEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantCreateEditModel, Plant>(form);

            //CreateRequest<Plant> request = new CreateRequest<Plant>(item);

            ICreateResponse<Plant> response = _dataService.Create(item);
        }
    }
}