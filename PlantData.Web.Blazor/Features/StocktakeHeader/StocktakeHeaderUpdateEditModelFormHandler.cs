using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.StocktakeHeader;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Forms.StocktakeHeader
{
    public class StocktakeHeaderUpdateEditModelFormHandler : IFormHandler<StocktakeHeaderUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public StocktakeHeaderUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(StocktakeHeaderUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                CreateUpdateStocktakeHeaderDataModel item = _mapper.Map<StocktakeHeaderUpdateEditModel, CreateUpdateStocktakeHeaderDataModel>(form);

                // Update with PUT
                var uri = "api/Stocktake/" + form.Id;
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
}
