using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionCreateEditModelFormHandler : IFormHandler<PlantStockTransactionCreateEditModel>
    {
        private IPlantStockTransactionDataService _dataService;

        public PlantStockTransactionCreateEditModelFormHandler(IPlantStockTransactionDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionCreateEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionCreateEditModel, PlantStockTransaction>(form);

            CreateRequest<PlantStockTransaction> request = new CreateRequest<PlantStockTransaction>(item);

            ICreateResponse<PlantStockTransaction> response = _dataService.Create(request);
        }
    }
}