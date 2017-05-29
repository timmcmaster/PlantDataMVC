using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Core.Domain;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
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

            UpdateResponse<PlantStockTransaction> response = _dataService.Update(request);
        }
    }
}