using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantData.Web.Mvc.Models.EditModels.ProductPrice;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Forms.ProductPrice
{
    public class ProductPriceCreateEditModelFormHandler : IFormHandler<ProductPriceCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public ProductPriceCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ProductPriceCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to dataModel
                CreateUpdateProductPriceDataModel item = _mapper.Map<ProductPriceCreateEditModel, CreateUpdateProductPriceDataModel>(form);

                var uri = "api/ProductPrice";
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