using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.PriceListType;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.PriceListType
{
    public class PriceListTypeCreateEditModelFormHandler : IFormHandler<PriceListTypeCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public PriceListTypeCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PriceListTypeCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to dataModel
                CreateUpdatePriceListTypeDataModel item = _mapper.Map<PriceListTypeCreateEditModel, CreateUpdatePriceListTypeDataModel>(form);

                var uri = "api/PriceListType";
                var response = await _plantDataApiClient.PostAsync<CreateUpdatePriceListTypeDataModel>(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }

    }
}