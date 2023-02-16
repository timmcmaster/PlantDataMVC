using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.ProductType;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.ProductType
{
    public class ProductTypeCreateEditModelFormHandler : IFormHandler<ProductTypeCreateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public ProductTypeCreateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ProductTypeCreateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to dataModel
                CreateUpdateProductTypeDataModel item = _mapper.Map<ProductTypeCreateEditModel, CreateUpdateProductTypeDataModel>(form);

                var uri = "api/ProductType";
                var response = await _plantDataApiClient.PostAsync<CreateUpdateProductTypeDataModel>(uri, item, cancellationToken).ConfigureAwait(false);

                return response.Success;
            }
            catch
            {
                return false;
            }
        }

    }
}