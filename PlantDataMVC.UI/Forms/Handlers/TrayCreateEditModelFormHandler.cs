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
    public class TrayCreateEditModelFormHandler : IFormHandler<TrayCreateEditModel>
    {
        private readonly HttpClient _httpClient;

        public TrayCreateEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(TrayCreateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SeedTrayDto item = AutoMapper.Mapper.Map<TrayCreateEditModel, SeedTrayDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpResponse = await _httpClient.PostAsync("api/SeedTray/", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}