﻿using System.Threading.Tasks;
using Framework.Web.Forms;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Models.EditModels;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class TrayDestroyEditModelFormHandler : IFormHandler<TrayDestroyEditModel>
    {
        private readonly ISeedTrayWcfService _dataService;

        public TrayDestroyEditModelFormHandler(ISeedTrayWcfService dataService)
        {
            _dataService = dataService;
        }

        public async Task<bool> HandleAsync(TrayDestroyEditModel form)
        {
            //TODO: convert to http api methods
            IDeleteResponse<SeedTrayDto> response = _dataService.Delete(form.Id);
            return (response.Status == ServiceActionStatus.Deleted);
        }
    }
}