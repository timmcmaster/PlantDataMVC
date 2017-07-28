using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayCreateEditModelFormHandler : IFormHandler<TrayCreateEditModel>
    {
        private IBasicDataService<PlantSeedTray> _dataService;

        public TrayCreateEditModelFormHandler(IBasicDataService<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayCreateEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayCreateEditModel, PlantSeedTray>(form);

            CreateRequest<PlantSeedTray> request = new CreateRequest<PlantSeedTray>(item);

            CreateResponse<PlantSeedTray> response = _dataService.Create(request);
        }
    }
}