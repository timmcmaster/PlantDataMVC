using Framework.Web.Forms;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.EditModels.SaleEvent;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Forms.SaleEvent
{
    public class SaleEventDestroyEditModelFormHandler : IFormHandler<SaleEventDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SaleEventDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(SaleEventDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/SaleEvent/" + form.Id;
                var httpResponse = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}