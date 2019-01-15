using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel>
    {
        private ISiteWcfService _dataService;

        public SiteCreateEditModelFormHandler(ISiteWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteCreateEditModel form)
        {
            // Map local model to business object
            SiteDTO item = AutoMapper.Mapper.Map<SiteCreateEditModel, SiteDTO>(form);

            //CreateRequest<SiteDTO> request = new CreateRequest<SiteDTO>(item);

            ICreateResponse<SiteDTO> response = _dataService.Create(item);
        }
    }
}