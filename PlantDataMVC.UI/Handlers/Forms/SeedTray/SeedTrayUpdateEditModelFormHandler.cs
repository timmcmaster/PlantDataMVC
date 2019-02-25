using System.Net.Http;
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
    public class SeedTrayUpdateEditModelFormHandler : IFormHandler<SeedTrayUpdateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedTrayUpdateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SeedTrayUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedTrayDto item = AutoMapper.Mapper.Map<SeedTrayUpdateEditModel, SeedTrayDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                var uri = "api/SeedTray/" + form.Id;
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