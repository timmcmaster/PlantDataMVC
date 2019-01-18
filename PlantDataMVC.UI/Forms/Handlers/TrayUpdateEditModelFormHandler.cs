using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayUpdateEditModelFormHandler : IFormHandler<TrayUpdateEditModel>
    {
        private ISeedTrayWcfService _dataService;

        public TrayUpdateEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayUpdateEditModel form)
        {
            // Map local model to DTO
            var item = AutoMapper.Mapper.Map<TrayUpdateEditModel, SeedTrayDto>(form);

            var response = _dataService.Update(item.Id, item);
        }
    }
}