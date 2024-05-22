using AutoMapper;
using Framework.Web.Forms;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.StocktakeHeader;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.StocktakeHeader
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
                var uri = "api/StocktakeHeader/" + form.Id;
                var response = await _plantDataApiClient.PutAsync<CreateUpdateStocktakeHeaderDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
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