using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionUpdateEditModelFormHandler : IFormHandler<PlantStockTransactionUpdateEditModel>
    {
        private IPlantStockTransactionDataService _dataService;

        public PlantStockTransactionUpdateEditModelFormHandler(IPlantStockTransactionDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionUpdateEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionUpdateEditModel, PlantStockTransaction>(form);

            //UpdateRequest<PlantStockTransaction> request = new UpdateRequest<PlantStockTransaction>(item);

            IUpdateResponse<PlantStockTransaction> response = _dataService.Update(item);
        }
    }
}