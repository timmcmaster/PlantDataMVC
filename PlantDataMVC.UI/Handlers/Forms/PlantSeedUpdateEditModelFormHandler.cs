using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;

namespace PlantDataMVC.UI.Handlers.Forms
{
    public class PlantSeedUpdateEditModelFormHandler : IFormHandler<PlantSeedUpdateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public PlantSeedUpdateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(PlantSeedUpdateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SeedBatchDto item = AutoMapper.Mapper.Map<PlantSeedUpdateEditModel, SeedBatchDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.PutAsync("api/SeedBatch/" + form.Id, content).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}