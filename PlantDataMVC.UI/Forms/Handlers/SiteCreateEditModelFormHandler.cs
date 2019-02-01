using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.UI.Forms.Handlers
{
    public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel>
    {
        private readonly HttpClient _httpClient;

        public SiteCreateEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
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

                var httpResponse = await _httpClient.PostAsync("api/Site/", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}