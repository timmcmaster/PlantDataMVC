using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.UI.Models;
using PlantDataMVC.Domain.Entities;
using Framework.Service.ServiceLayer;

namespace PlantDataMVC.UI.Helpers.Handlers
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