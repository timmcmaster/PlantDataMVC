using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.EditModels.Genus;

namespace PlantDataMVC.UI.Handlers.Forms.Genus
{
    public class GenusUpdateEditModelFormHandler : IFormHandler<GenusUpdateEditModel, bool>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public GenusUpdateEditModelFormHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

                var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
                // todo: if not null client
                var httpResponse = await httpClient.PutAsync("api/Genus/" + form.Id, content).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}