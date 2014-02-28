using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMvc3.UI.Models;
using PlantDataMvc3.Core.Domain;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;

namespace PlantDataMvc3.UI.Helpers.Handlers
{
    public class PlantStockEntryCreateEditModelFormHandler : IFormHandler<PlantStockEntryCreateEditModel>
    {
        private IBasicDataService<PlantStockEntry> _dataService;

        public PlantStockEntryCreateEditModelFormHandler(IBasicDataService<PlantStockEntry> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantStockEntryCreateEditModel form)
        {
            // Map local model to business object
            PlantStockEntry item = AutoMapper.Mapper.Map<PlantStockEntryCreateEditModel, PlantStockEntry>(form);

            CreateRequest<PlantStockEntry> request = new CreateRequest<PlantStockEntry>(item);

            CreateResponse<PlantStockEntry> response = _dataService.Create(request);
        }
    }
}