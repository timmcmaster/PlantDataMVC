using Framework.Web.Forms;
using PlantDataMVC.Common.Client;
using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using PlantData.Web.Mvc.Models.EditModels.StocktakeHeader;

namespace PlantData.Web.Mvc.Handlers.Forms.StocktakeHeader
{
    public class StocktakeHeaderDestroyEditModelFormHandler : IFormHandler<StocktakeHeaderDestroyEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public StocktakeHeaderDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<bool> Handle(StocktakeHeaderDestroyEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                var uri = "api/StocktakeHeader/" + form.Id;
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