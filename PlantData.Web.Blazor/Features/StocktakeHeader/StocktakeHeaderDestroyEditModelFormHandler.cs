using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.StocktakeHeader;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.StocktakeHeader;

public class StocktakeHeaderDestroyEditModelFormHandler : IFormHandler<StocktakeHeaderDestroyEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public StocktakeHeaderDestroyEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
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
