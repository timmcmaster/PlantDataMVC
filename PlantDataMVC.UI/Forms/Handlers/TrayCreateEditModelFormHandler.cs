using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayCreateEditModelFormHandler : IFormHandler<TrayCreateEditModel>
    {
        private IPlantSeedTrayDataService _dataService;

        public TrayCreateEditModelFormHandler(IPlantSeedTrayDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayCreateEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayCreateEditModel, PlantSeedTray>(form);

            CreateRequest<PlantSeedTray> request = new CreateRequest<PlantSeedTray>(item);

            ICreateResponse<PlantSeedTray> response = _dataService.Create(request);
        }
    }
}