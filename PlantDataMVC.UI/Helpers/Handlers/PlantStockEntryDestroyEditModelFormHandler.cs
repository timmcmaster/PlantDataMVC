﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
{
    public class PlantStockEntryDestroyEditModelFormHandler : IFormHandler<PlantStockEntryDestroyEditModel>
    {
        private IBasicDataService<PlantStockEntry> _dataService;

        public PlantStockEntryDestroyEditModelFormHandler(IBasicDataService<PlantStockEntry> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryDestroyEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryDestroyEditModel, PlantStockEntry>(form);

            DeleteRequest<PlantStockEntry> request = new DeleteRequest<PlantStockEntry>(item.Id);

            DeleteResponse<PlantStockEntry> response = _dataService.Delete(request);
        }
    }
}