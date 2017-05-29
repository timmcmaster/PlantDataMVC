using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class PlantStockTransactionDestroyEditModelFormHandler : IFormHandler<PlantStockTransactionDestroyEditModel>
    {
        private IBasicDataService<PlantStockTransaction> _dataService;

        public PlantStockTransactionDestroyEditModelFormHandler(IBasicDataService<PlantStockTransaction> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionDestroyEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionDestroyEditModel, PlantStockTransaction>(form);

            DeleteRequest<PlantStockTransaction> request = new DeleteRequest<PlantStockTransaction>(item.Id);

            DeleteResponse<PlantStockTransaction> response = _dataService.Delete(request);
        }
    }
}