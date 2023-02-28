using AutoMapper;
using Framework.Web.Views;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries.ProductPrice;
using PlantDataMVC.Web.Models.ViewModels.ProductPrice;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.ProductPrice
{
    public class EditQueryHandler : IQueryHandler<EditQuery, ProductPriceEditViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public EditQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ProductPriceEditViewModel> Handle(EditQuery query, CancellationToken cancellationToken)
        {
            var uri = $"api/ProductPrice?productTypeId={query.ProductTypeId}&priceListId={query.PriceListTypeId}&strEffectiveDate={query.DateEffective.ToString("yyyyMMdd")}";
            var response = await _plantDataApiClient.GetAsync<ProductPriceDataModel>(uri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var model = _mapper.Map<ProductPriceDataModel, ProductPriceEditViewModel>(response.Content);
                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}