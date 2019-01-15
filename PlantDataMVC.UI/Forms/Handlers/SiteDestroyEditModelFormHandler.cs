using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
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
            // Map local model to business object
            SiteDTO item = AutoMapper.Mapper.Map<SiteDestroyEditModel, SiteDTO>(form);

            //DeleteRequest<SiteDTO> request = new DeleteRequest<SiteDTO>(item.Id);

            IDeleteResponse<SiteDTO> response = _dataService.Delete(item.Id);

            //TODO: Need behaviour triggered on non zero error-code in response
            if (response.Status == Interfaces.Service.ServiceActionStatus.Deleted)
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