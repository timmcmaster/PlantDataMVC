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
    public class PlantStockUpdateEditModelFormHandler : IFormHandler<PlantStockUpdateEditModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantStockUpdateEditModelFormHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> HandleAsync(PlantStockUpdateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                PlantStockDto item = AutoMapper.Mapper.Map<PlantStockUpdateEditModel, PlantStockDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.PutAsync("api/PlantStock/" + form.Id, content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}