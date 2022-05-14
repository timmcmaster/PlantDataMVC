using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.SeedTray;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.SeedTray
{
    public class SeedTrayUpdateEditModelFormHandler : IFormHandler<SeedTrayUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedTrayUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SeedTrayUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedTrayDto item = AutoMapper.Mapper.Map<SeedTrayUpdateEditModel, SeedTrayDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/SeedTray/" + form.Id;
                var httpResponse = await _plantDataApiClient.PutAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}