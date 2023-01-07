using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.PlantStock;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.PlantStock
{
    public class PlantStockDestroyEditModelFormHandler : IFormHandler<PlantStockDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public PlantStockDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(PlantStockDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/PlantStock/" + form.Id;
                var response = await _plantDataApiClient.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    return response.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}