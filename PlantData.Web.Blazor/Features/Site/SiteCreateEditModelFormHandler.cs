using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.Site;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Site;

public class SiteCreateEditModelFormHandler : IFormHandler<SiteCreateEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public SiteCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<bool> Handle(SiteCreateEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            // Map local model to DTO
            CreateUpdateSiteDataModel item = _mapper.Map<SiteCreateEditModel, CreateUpdateSiteDataModel>(form);

            var uri = "api/Site";
            var response = await _plantDataApiClient.PostAsync(uri, item, cancellationToken).ConfigureAwait(false);

            return response.Success;
        }
        catch
        {
            return false;
        }
    }
}