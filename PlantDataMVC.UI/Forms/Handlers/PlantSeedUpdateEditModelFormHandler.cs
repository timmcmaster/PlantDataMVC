using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel>
    {
        private IPlantSeedDataService _dataService;

        public PlantSeedUpdateEditModelFormHandler(IPlantSeedDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, PlantSeed>(form);

            //UpdateRequest<PlantSeed> request = new UpdateRequest<PlantSeed>(item);

            IUpdateResponse<PlantSeed> response = _dataService.Update(item.Id,item);
        }
    }
}