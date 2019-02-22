using System.Net.Http;
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
    public class SeedBatchUpdateEditModelFormHandler : IFormHandler<SeedBatchUpdateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedBatchUpdateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedBatchUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SeedBatchDto item = AutoMapper.Mapper.Map<SeedBatchUpdateEditModel, SeedBatchDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var uri = "api/SeedBatch/" + form.Id;
                var httpResponse = await httpClient.PutAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}