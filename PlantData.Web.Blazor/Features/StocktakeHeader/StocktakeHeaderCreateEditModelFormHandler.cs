using AutoMapper;
using Framework.Web.Forms;
using PlantData.Web.Blazor.UIModels.EditModels.StocktakeHeader;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Forms.StocktakeHeader
{
    public class StocktakeHeaderCreateEditModelFormHandler : IFormHandler<StocktakeHeaderCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public StocktakeHeaderCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(StocktakeHeaderCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to dataModel
                CreateUpdateStocktakeHeaderDataModel item = _mapper.Map<StocktakeHeaderCreateEditModel, CreateUpdateStocktakeHeaderDataModel>(form);

                var uri = "api/Stocktake";
                var response = await _plantDataApiClient.PostAsync(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }

    }
}
