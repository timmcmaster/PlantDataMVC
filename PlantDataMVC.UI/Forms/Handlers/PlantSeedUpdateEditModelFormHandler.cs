using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel>
    {
        private ISeedBatchWcfService _dataService;

        public PlantSeedUpdateEditModelFormHandler(ISeedBatchWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedUpdateEditModel form)
        {
            // Map local model to business object
            // TODO: Check map exists
            SeedBatchDTO item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, SeedBatchDTO>(form);

            //UpdateRequest<SeedBatchDTO> request = new UpdateRequest<SeedBatchDTO>(item);

            IUpdateResponse<SeedBatchDTO> response = _dataService.Update(item.Id,item);
        }
    }
}