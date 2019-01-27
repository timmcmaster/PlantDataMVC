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
    public class GenusUpdateEditModelFormHandler : IFormHandler<GenusUpdateEditModel>
    {
        private readonly HttpClient _httpClient;

        public GenusUpdateEditModelFormHandler()
        {
            _httpClient = MyHttpClient.GetClient();
        }

        public async Task<bool> HandleAsync(GenusUpdateEditModel form)
        {
            try
            {
                // Map local model to DTO
                // TODO: Check map exists
                CreateUpdateGenusDto item = AutoMapper.Mapper.Map<GenusUpdateEditModel, CreateUpdateGenusDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var httpResponse = await _httpClient.PutAsync("api/Genus/" + form.Id, content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}