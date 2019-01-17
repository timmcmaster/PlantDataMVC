using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
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
            // Map local model to DTO
            // TODO: Check map exists
            var item = AutoMapper.Mapper.Map<SiteCreateEditModel, SiteDto>(form);

            var response = _dataService.Create(item);
        }
    }
}