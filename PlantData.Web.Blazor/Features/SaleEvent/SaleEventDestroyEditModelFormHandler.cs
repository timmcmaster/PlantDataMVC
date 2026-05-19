using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.SaleEvent;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.SaleEvent;

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