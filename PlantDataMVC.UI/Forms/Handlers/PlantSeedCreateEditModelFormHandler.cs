using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedCreateEditModelFormHandler : IFormHandler<PlantSeedCreateEditModel>
    {
        private ISeedBatchWcfService _dataService;

        public PlantSeedCreateEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedCreateEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SeedBatchDTO item = AutoMapper.Mapper.Map<PlantSeedCreateEditModel, SeedBatchDTO>(form);

            //CreateRequest<SeedBatchDTO> request = new CreateRequest<SeedBatchDTO>(item);

            ICreateResponse<SeedBatchDTO> response = _dataService.Create(item);
        }
    }
}