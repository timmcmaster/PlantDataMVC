using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionDestroyEditModelFormHandler : IFormHandler<PlantStockTransactionDestroyEditModel>
    {
        private IPlantStockTransactionDataService _dataService;

        public PlantStockTransactionDestroyEditModelFormHandler(IPlantStockTransactionDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionDestroyEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionDestroyEditModel, PlantStockTransaction>(form);

            //DeleteRequest<PlantStockTransaction> request = new DeleteRequest<PlantStockTransaction>(item.Id);

            IDeleteResponse<PlantStockTransaction> response = _dataService.Delete(item.Id);
        }
    }
}