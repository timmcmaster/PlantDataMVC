using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayDestroyEditModelFormHandler : IFormHandler<TrayDestroyEditModel>
    {
        private IDataServiceBase<PlantSeedTray> _dataService;

        public TrayDestroyEditModelFormHandler(IDataServiceBase<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayDestroyEditModel, PlantSeedTray>(form);

            DeleteRequest<PlantSeedTray> request = new DeleteRequest<PlantSeedTray>(item.Id);

            IDeleteResponse<PlantSeedTray> response = _dataService.Delete(request);
        }
    }
}