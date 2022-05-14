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
    public class SeedBatchEditModelFormHandler : IFormHandler<SeedBatchCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedBatchEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> HandleAsync(SeedBatchCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                SeedBatchDto item = AutoMapper.Mapper.Map<SeedBatchCreateEditModel, SeedBatchDto>(form);
                var serializedItem = JsonConvert.SerializeObject(item);
                var content = new StringContent(serializedItem, Encoding.Unicode, "application/json");

                var uri = "api/SeedBatch";
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