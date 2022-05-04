﻿using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.UICore.Models.EditModels.Genus;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.Genus
{
    public class GenusCreateEditModelFormHandler : IFormHandler<GenusCreateEditModel, bool>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GenusCreateEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(GenusCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateGenusDto item = AutoMapper.Mapper.Map<GenusCreateEditModel, CreateUpdateGenusDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/Genus";
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