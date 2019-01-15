using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
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
            // Map local model to business object
            SeedTrayDTO item = AutoMapper.Mapper.Map<TrayUpdateEditModel, SeedTrayDTO>(form);

            //UpdateRequest<SeedTrayDTO> request = new UpdateRequest<SeedTrayDTO>(item);

            IUpdateResponse<SeedTrayDTO> response = _dataService.Update(item.Id, item);
        }
    }
}