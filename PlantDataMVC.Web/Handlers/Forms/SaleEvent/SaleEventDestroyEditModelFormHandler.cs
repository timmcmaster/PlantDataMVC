﻿using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.SaleEvent;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.SaleEvent
{
    public class SaleEventDestroyEditModelFormHandler : IFormHandler<SaleEventDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SaleEventDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(SaleEventDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/SaleEvent/" + form.Id;
                var response = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}