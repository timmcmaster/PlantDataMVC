using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.Site;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Site;

public class SiteDestroyEditModelFormHandler : IFormHandler<SiteDestroyEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;

    public SiteDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient)
    {
        _plantDataApiClient = plantDataApiClient;
    }

    public async Task<bool> Handle(SiteDestroyEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            var uri = "api/Site/" + form.Id;
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