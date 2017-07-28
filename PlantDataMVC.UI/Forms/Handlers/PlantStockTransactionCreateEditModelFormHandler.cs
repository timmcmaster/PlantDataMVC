﻿using Framework.Service.ServiceLayer;
using Framework.Web.Forms;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockTransactionCreateEditModelFormHandler : IFormHandler<PlantStockTransactionCreateEditModel>
    {
        private IBasicDataService<PlantStockTransaction> _dataService;

        public PlantStockTransactionCreateEditModelFormHandler(IBasicDataService<PlantStockTransaction> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockTransactionCreateEditModel form)
        {
            // Map local model to business object
            PlantStockTransaction item = AutoMapper.Mapper.Map<PlantStockTransactionCreateEditModel, PlantStockTransaction>(form);

            CreateRequest<PlantStockTransaction> request = new CreateRequest<PlantStockTransaction>(item);

            CreateResponse<PlantStockTransaction> response = _dataService.Create(request);
        }
    }
}