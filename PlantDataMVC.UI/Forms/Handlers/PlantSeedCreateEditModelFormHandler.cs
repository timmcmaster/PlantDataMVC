using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantSeedCreateEditModelFormHandler : IFormHandler<PlantSeedCreateEditModel>
    {
        private IBasicDataService<PlantSeed> _dataService;

        public PlantSeedCreateEditModelFormHandler(IBasicDataService<PlantSeed> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedCreateEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedCreateEditModel, PlantSeed>(form);

            CreateRequest<PlantSeed> request = new CreateRequest<PlantSeed>(item);

            CreateResponse<PlantSeed> response = _dataService.Create(request);
        }
    }
}