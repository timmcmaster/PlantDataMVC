using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedDestroyEditModelFormHandler : IFormHandler<PlantSeedDestroyEditModel>
    {
        private ISeedBatchWcfService _dataService;

        public PlantSeedDestroyEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedDestroyEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SeedBatchDTO item = AutoMapper.Mapper.Map<PlantSeedDestroyEditModel, SeedBatchDTO>(form);

            //DeleteRequest<SeedBatchDTO> request = new DeleteRequest<SeedBatchDTO>(item.Id);

            IDeleteResponse<SeedBatchDTO> response = _dataService.Delete(item.Id);
        }
    }
}