﻿using System.Threading.Tasks;
using Framework.Web.Forms;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.Site;

namespace PlantDataMVC.UI.Handlers.Forms.Site
{
    public class SiteDestroyEditModelFormHandler : IFormHandler<SiteDestroyEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SiteDestroyEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SiteDestroyEditModel form)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.DeleteAsync("api/Site/" + form.Id).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}