﻿using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.SeedBatch;

namespace PlantDataMVC.UI.Handlers.Forms.SeedBatch
{
    public class SeedBatchEditModelFormHandler : IFormHandler<SeedBatchCreateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedBatchEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedBatchCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedBatchDto item = AutoMapper.Mapper.Map<SeedBatchCreateEditModel, SeedBatchDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/SeedBatch";
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