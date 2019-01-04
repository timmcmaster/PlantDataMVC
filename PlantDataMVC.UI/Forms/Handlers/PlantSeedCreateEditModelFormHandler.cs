using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedCreateEditModelFormHandler : IFormHandler<PlantSeedCreateEditModel>
    {
        private IPlantSeedDataService _dataService;

        public PlantSeedCreateEditModelFormHandler(IPlantSeedDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedCreateEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedCreateEditModel, PlantSeed>(form);

            //CreateRequest<PlantSeed> request = new CreateRequest<PlantSeed>(item);

            ICreateResponse<PlantSeed> response = _dataService.Create(item);
        }
    }
}