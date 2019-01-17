using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private ISpeciesWcfService _dataService;

        public PlantDestroyEditModelFormHandler(ISpeciesWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantDestroyEditModel form)
        {
            var response = _dataService.Delete(form.Id);
        }
    }
}