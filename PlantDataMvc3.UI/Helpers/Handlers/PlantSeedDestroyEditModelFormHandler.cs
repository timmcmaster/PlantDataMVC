using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;
using PlantDataMvc3.UI.Models;

namespace PlantDataMvc3.UI.Helpers.Handlers
{
    public class PlantSeedDestroyEditModelFormHandler : IFormHandler<PlantSeedDestroyEditModel>
    {
        private IBasicDataService<PlantSeed> _dataService;

        public PlantSeedDestroyEditModelFormHandler(IBasicDataService<PlantSeed> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantSeedDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeed item = AutoMapper.Mapper.Map<PlantSeedDestroyEditModel, PlantSeed>(form);

            DeleteRequest<PlantSeed> request = new DeleteRequest<PlantSeed>(item.Id);

            DeleteResponse<PlantSeed> response = _dataService.Delete(request);
        }
    }
}