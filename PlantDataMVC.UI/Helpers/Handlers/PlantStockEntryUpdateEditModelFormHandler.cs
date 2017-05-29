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
    public class PlantStockEntryUpdateEditModelFormHandler : IFormHandler<PlantStockEntryUpdateEditModel>
    {
        private IBasicDataService<PlantStockEntry> _dataService;

        public PlantStockEntryUpdateEditModelFormHandler(IBasicDataService<PlantStockEntry> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryUpdateEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryUpdateEditModel, PlantStockEntry>(form);

            UpdateRequest<PlantStockEntry> request = new UpdateRequest<PlantStockEntry>(item);

            UpdateResponse<PlantStockEntry> response = _dataService.Update(request);
        }
    }
}