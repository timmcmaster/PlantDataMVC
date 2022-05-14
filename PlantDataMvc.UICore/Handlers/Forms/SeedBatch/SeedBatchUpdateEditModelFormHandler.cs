using Framework.Web.Core.Forms;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.SeedBatch;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.SeedBatch
{
    public class SeedBatchUpdateEditModelFormHandler : IFormHandler<SeedBatchUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedBatchUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SeedBatchUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedBatchDto item = AutoMapper.Mapper.Map<SeedBatchUpdateEditModel, SeedBatchDto>(form);

                // Update with PUT
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/SeedBatch/" + form.Id;
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