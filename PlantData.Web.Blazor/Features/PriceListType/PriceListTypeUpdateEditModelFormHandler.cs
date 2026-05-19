using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.PriceListType;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.PriceListType;

public class PriceListTypeUpdateEditModelFormHandler : IFormHandler<PriceListTypeUpdateEditModel, bool>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public PriceListTypeUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<bool> Handle(PriceListTypeUpdateEditModel form, CancellationToken cancellationToken)
    {
        try
        {
            // Map local model to DTO
            CreateUpdatePriceListTypeDataModel item = _mapper.Map<PriceListTypeUpdateEditModel, CreateUpdatePriceListTypeDataModel>(form);

            // Update with PUT
            var uri = "api/PriceListType/" + form.Id;
            var response = await _plantDataApiClient.PutAsync(uri, item, cancellationToken).ConfigureAwait(false);
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
