using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionUpdateEditModelFormHandler : IFormHandler<PlantStockTransactionUpdateEditModel>
    {
        private IBasicDataService<PlantStockTransaction> _dataService;

        public PlantStockTransactionUpdateEditModelFormHandler(IBasicDataService<PlantStockTransaction> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionUpdateEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionUpdateEditModel, PlantStockTransaction>(form);

            UpdateRequest<PlantStockTransaction> request = new UpdateRequest<PlantStockTransaction>(item);

            IUpdateResponse<PlantStockTransaction> response = _dataService.Update(request);
        }
    }
}