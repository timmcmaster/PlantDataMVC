﻿using Framework.Web.Forms;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.UI.Models;
using PlantDataMVC.dataService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayCreateEditModelFormHandler : IFormHandler<TrayCreateEditModel>
    {
        private ISeedTrayWcfService _dataService;

        public TrayCreateEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(TrayCreateEditModel form)
        {
            // Map local model to business object
            SeedTrayDTO item = AutoMapper.Mapper.Map<TrayCreateEditModel, SeedTrayDTO>(form);

            //CreateRequest<SeedTrayDTO> request = new CreateRequest<SeedTrayDTO>(item);

            ICreateResponse<SeedTrayDTO> response = _dataService.Create(item);
        }
    }
}