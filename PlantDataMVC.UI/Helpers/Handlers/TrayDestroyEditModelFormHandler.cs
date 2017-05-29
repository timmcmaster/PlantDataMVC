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
    public class TrayDestroyEditModelFormHandler : IFormHandler<TrayDestroyEditModel>
    {
        private IBasicDataService<PlantSeedTray> _dataService;

        public TrayDestroyEditModelFormHandler(IBasicDataService<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayDestroyEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayDestroyEditModel, PlantSeedTray>(form);

            DeleteRequest<PlantSeedTray> request = new DeleteRequest<PlantSeedTray>(item.Id);

            DeleteResponse<PlantSeedTray> response = _dataService.Delete(request);
        }
    }
}