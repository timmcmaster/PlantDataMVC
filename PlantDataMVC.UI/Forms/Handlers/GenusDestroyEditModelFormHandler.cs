using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class GenusDestroyEditModelFormHandler : IFormHandler<GenusDestroyEditModel>
    {
        private IGenusWcfService _dataService;

        public GenusDestroyEditModelFormHandler(IGenusWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(GenusDestroyEditModel form)
        {
            var response = _dataService.Delete(form.Id);
        }
    }
}