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
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SiteCreateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(SiteCreateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SiteDto item = AutoMapper.Mapper.Map<SiteCreateEditModel, SiteDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.PostAsync("api/Site", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}