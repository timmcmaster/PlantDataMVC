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
    public class PlantCreateEditModelFormHandler : IFormHandler<PlantCreateEditModel>
    {
        private readonly HttpClient _httpClient;

        public PlantCreateEditModelFormHandler()
        {
            _httpClient = MyHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(PlantCreateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                SpeciesDto item = AutoMapper.Mapper.Map<PlantCreateEditModel, SpeciesDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpResponse = await _httpClient.PostAsync("api/Species/", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}