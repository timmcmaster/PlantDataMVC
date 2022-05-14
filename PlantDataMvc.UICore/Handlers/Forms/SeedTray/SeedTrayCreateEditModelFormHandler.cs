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
    public class SeedTrayCreateEditModelFormHandler : IFormHandler<SeedTrayCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedTrayCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SeedTrayCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedTrayDto item = AutoMapper.Mapper.Map<SeedTrayCreateEditModel, SeedTrayDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/SeedTray";
                var httpResponse = await _plantDataApiClient.PostAsync(uri, content, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}