using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
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
            // Map local model to business object
            SeedTrayDTO item = AutoMapper.Mapper.Map<TrayDestroyEditModel, SeedTrayDTO>(form);

            //DeleteRequest<SeedTrayDTO> request = new DeleteRequest<SeedTrayDTO>(item.Id);

            IDeleteResponse<SeedTrayDTO> response = _dataService.Delete(item.Id);
        }
    }
}