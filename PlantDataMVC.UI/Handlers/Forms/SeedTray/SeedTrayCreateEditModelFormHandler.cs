﻿using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.SeedTray;

namespace PlantDataMVC.UI.Handlers.Forms.SeedTray
{
    public class SeedTrayCreateEditModelFormHandler : IFormHandler<SeedTrayCreateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedTrayCreateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedTrayCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedTrayDto item = AutoMapper.Mapper.Map<SeedTrayCreateEditModel, SeedTrayDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var uri = "api/SeedTray";
                var httpResponse = await httpClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}