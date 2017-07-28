using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;
using Framework.Web.Forms;

namespace PlantDataMVC.UI.Forms.Handlers
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