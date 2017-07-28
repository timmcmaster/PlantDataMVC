using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayDestroyEditModelFormHandler : IFormHandler<TrayDestroyEditModel>
    {
        private IBasicDataService<PlantSeedTray> _dataService;

        public TrayDestroyEditModelFormHandler(IBasicDataService<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayDestroyEditModel, PlantSeedTray>(form);

            DeleteRequest<PlantSeedTray> request = new DeleteRequest<PlantSeedTray>(item.Id);

            DeleteResponse<PlantSeedTray> response = _dataService.Delete(request);
        }
    }
}