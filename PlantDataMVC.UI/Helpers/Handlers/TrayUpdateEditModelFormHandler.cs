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
    public class TrayUpdateEditModelFormHandler : IFormHandler<TrayUpdateEditModel>
    {
        private IBasicDataService<PlantSeedTray> _dataService;

        public TrayUpdateEditModelFormHandler(IBasicDataService<PlantSeedTray> dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayUpdateEditModel form)
        {
            // Map local model to business object
            PlantSeedTray item = AutoMapper.Mapper.Map<TrayUpdateEditModel, PlantSeedTray>(form);

            UpdateRequest<PlantSeedTray> request = new UpdateRequest<PlantSeedTray>(item);

            UpdateResponse<PlantSeedTray> response = _dataService.Update(request);
        }
    }
}