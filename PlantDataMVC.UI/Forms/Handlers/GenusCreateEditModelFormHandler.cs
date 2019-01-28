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
    public class GenusCreateEditModelFormHandler : IFormHandler<GenusCreateEditModel>
    {
        private readonly HttpClient _httpClient;

        public GenusCreateEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        // TODO: Look into how we might mock HttpClient for unit tests 
        public async Task<bool> HandleAsync(GenusCreateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                CreateUpdateGenusDto item = AutoMapper.Mapper.Map<GenusCreateEditModel, CreateUpdateGenusDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpResponse = await _httpClient.PostAsync("api/Genus/", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}