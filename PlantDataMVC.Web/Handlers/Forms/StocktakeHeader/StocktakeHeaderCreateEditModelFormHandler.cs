using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.StocktakeHeader;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.StocktakeHeader
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
                // Map local model to DTO
                CreateUpdateStocktakeHeaderDataModel item = _mapper.Map<StocktakeHeaderCreateEditModel, CreateUpdateStocktakeHeaderDataModel>(form);

                var uri = "api/StocktakeHeader";
                var response = await _plantDataApiClient.PostAsync<CreateUpdateStocktakeHeaderDataModel>(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}