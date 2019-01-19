using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayDestroyEditModelFormHandler : IFormHandler<TrayDestroyEditModel>
    {
        private ISeedTrayWcfService _dataService;

        public TrayDestroyEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayDestroyEditModel form)
        {
            IDeleteResponse<SeedTrayDto> response = _dataService.Delete(form.Id);
        }
    }
}