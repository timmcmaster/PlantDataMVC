using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantUpdateEditModelFormHandler : IFormHandler<PlantUpdateEditModel>
    {
        private IBasicDataService<Plant> _dataService;

        public PlantUpdateEditModelFormHandler(IBasicDataService<Plant> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantUpdateEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantUpdateEditModel, Plant>(form);

            UpdateRequest<Plant> request = new UpdateRequest<Plant>(item);

            UpdateResponse<Plant> response = _dataService.Update(request);
        }
    }
}