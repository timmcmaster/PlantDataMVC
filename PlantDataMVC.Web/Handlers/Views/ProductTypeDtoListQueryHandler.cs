using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.UICore.Controllers.Queries;
using PlantDataMVC.UICore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views
{
    public class ProductTypeDataModelListQueryHandler : ListQueryHandler<ProductTypeDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public ProductTypeDataModelListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<ProductTypeDataModel>> Handle(ListQuery<ProductTypeDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/ProductType";
            IEnumerable<ProductTypeDataModel> fullDataModelList = Enumerable.Empty<ProductTypeDataModel>();

            while (!String.IsNullOrEmpty(uri))
            {
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dataModelList = JsonConvert.DeserializeObject<IEnumerable<ProductTypeDataModel>>(content);

                    // Concatenate page to full list
                    fullDataModelList = (fullDataModelList ?? Enumerable.Empty<ProductTypeDataModel>()).Concat(dataModelList ?? Enumerable.Empty<ProductTypeDataModel>());

                    // if we haven't got all the items, follow paging links (link will be null if no next page)
                    uri = linkInfo.NextPageLink?.ToString();
                }
                else
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                return fullDataModelList;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}