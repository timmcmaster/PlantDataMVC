using AutoMapper;
using Framework.Web.Forms;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Models.EditModels.ProductPrice;
using System.Net;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Forms.ProductPrice
{
    public class ProductPriceUpdateEditModelFormHandler : IFormHandler<ProductPriceUpdateEditModel, bool>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public ProductPriceUpdateEditModelFormHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ProductPriceUpdateEditModel form, CancellationToken cancellationToken)
        {
            try
            {
                // Map local model to DTO
                ProductPriceDataModel item = _mapper.Map<ProductPriceUpdateEditModel, ProductPriceDataModel>(form);

                // Update with PUT
                var uri = $"api/ProductPrice?productTypeId={form.ProductTypeId}&priceListId={form.PriceListTypeId}&strEffectiveDate={form.DateEffective.ToString("yyyyMMdd")}";
                var response = await _plantDataApiClient.PutAsync<ProductPriceDataModel>(uri, item, cancellationToken).ConfigureAwait(false);
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