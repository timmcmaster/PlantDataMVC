using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantUpdateEditModelFormHandler : IFormHandler<PlantUpdateEditModel>
    {
        private IPlantDataService _dataService;

        public PlantUpdateEditModelFormHandler(IPlantDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantUpdateEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantUpdateEditModel, Plant>(form);

            //UpdateRequest<Plant> request = new UpdateRequest<Plant>(item);

            IUpdateResponse<Plant> response = _dataService.Update(item.Id, item);
        }
    }
}