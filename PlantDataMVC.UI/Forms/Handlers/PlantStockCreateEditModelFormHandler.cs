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
    public class PlantStockCreateEditModelFormHandler : IFormHandler<PlantStockCreateEditModel>
    {
        private readonly HttpClient _httpClient;

        public PlantStockCreateEditModelFormHandler()
        {
            _httpClient = PlantDataApiHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(PlantStockCreateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                PlantStockDto item = AutoMapper.Mapper.Map<PlantStockCreateEditModel, PlantStockDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpResponse = await _httpClient.PostAsync("api/PlantStock/", content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}