using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayUpdateEditModelFormHandler : IFormHandler<TrayUpdateEditModel>
    {
        private IBasicDataService<PlantSeedTray> _dataService;

        public TrayUpdateEditModelFormHandler(IBasicDataService<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayUpdateEditModel, PlantSeedTray>(form);

            UpdateRequest<PlantSeedTray> request = new UpdateRequest<PlantSeedTray>(item);

            IUpdateResponse<PlantSeedTray> response = _dataService.Update(request);
        }
    }
}