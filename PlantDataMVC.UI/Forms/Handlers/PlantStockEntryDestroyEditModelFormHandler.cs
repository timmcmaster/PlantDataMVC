﻿using Framework.Service.Entities;
using Framework.Web.Forms;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using PlantDataMVC.UI.Models;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class PlantStockEntryDestroyEditModelFormHandler : IFormHandler<PlantStockEntryDestroyEditModel>
    {
        private IPlantStockEntryDataService _dataService;

        public PlantStockEntryDestroyEditModelFormHandler(IPlantStockEntryDataService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryDestroyEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryDestroyEditModel, PlantStockEntry>(form);

            //DeleteRequest<PlantStockEntry> request = new DeleteRequest<PlantStockEntry>(item.Id);

            IDeleteResponse<PlantStockEntry> response = _dataService.Delete(item.Id);
        }
    }
}