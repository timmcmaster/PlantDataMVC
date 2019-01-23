﻿using Framework.Web.Forms;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteUpdateEditModelFormHandler : IFormHandler<SiteUpdateEditModel>
    {
        private readonly ISiteWcfService _dataService;

        public SiteUpdateEditModelFormHandler(ISiteWcfService dataService)
        {
            _dataService = dataService;
        }

        public void Handle(SiteUpdateEditModel form)
        {
            // Map local model to DTO
            // TODO: Check map exists
            SiteDto item = AutoMapper.Mapper.Map<SiteUpdateEditModel, SiteDto>(form);

            IUpdateResponse<SiteDto> response = _dataService.Update(item.Id, item);
        }
    }
}