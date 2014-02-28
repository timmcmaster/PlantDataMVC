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
    public class PlantDestroyEditModelFormHandler : IFormHandler<PlantDestroyEditModel>
    {
        private IBasicDataService<Plant> _dataService;

        public PlantDestroyEditModelFormHandler(IBasicDataService<Plant> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(PlantDestroyEditModel form)
        {
            // Map local model to business object
            Plant item = AutoMapper.Mapper.Map<PlantDestroyEditModel, Plant>(form);

            DeleteRequest<Plant> request = new DeleteRequest<Plant>(item.Id);

            DeleteResponse<Plant> response = _dataService.Delete(request);
        }
    }
}