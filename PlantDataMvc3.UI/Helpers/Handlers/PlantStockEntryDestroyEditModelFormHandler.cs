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