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
    public class TrayUpdateEditModelFormHandler : IFormHandler<TrayUpdateEditModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrayUpdateEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(TrayUpdateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SeedTrayDto item = AutoMapper.Mapper.Map<TrayUpdateEditModel, SeedTrayDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.PutAsync("api/SeedTray/" + form.Id, content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}