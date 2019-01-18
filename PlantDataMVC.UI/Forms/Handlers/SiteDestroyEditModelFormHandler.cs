using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteDestroyEditModelFormHandler : IFormHandler<SiteDestroyEditModel>
    {
        private ISiteWcfService _dataService;

        public SiteDestroyEditModelFormHandler(ISiteWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteDestroyEditModel form)
        {
            var response = _dataService.Delete(form.Id);

            //TODO: Need behaviour triggered on bad response
            if (response.Status == ServiceActionStatus.Deleted)
            {
                // take good path
            }
            else
            {
                // take error path
                // either rethrow exception or display error message of sorts
            }
        }
    }
}