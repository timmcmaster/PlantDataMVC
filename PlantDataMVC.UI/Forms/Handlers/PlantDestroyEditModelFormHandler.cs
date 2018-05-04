using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private IBasicDataService<Plant> _dataService;

        public PlantDestroyEditModelFormHandler(IBasicDataService<Plant> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantDestroyEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantDestroyEditModel, Plant>(form);

            DeleteRequest<Plant> request = new DeleteRequest<Plant>(item.Id);

            IDeleteResponse<Plant> response = _dataService.Delete(request);
        }
    }
}