using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel>
    {
        private ISiteWcfService _dataService;

        public SiteUpdateEditModelFormHandler(ISiteWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteUpdateEditModel form)
        {
            // Map local model to business object
            SiteDTO item = AutoMapper.Mapper.Map<SiteUpdateEditModel, SiteDTO>(form);

            //UpdateRequest<SiteDTO> request = new UpdateRequest<SiteDTO>(item);

            IUpdateResponse<SiteDTO> response = _dataService.Update(item.Id, item);
        }
    }
}