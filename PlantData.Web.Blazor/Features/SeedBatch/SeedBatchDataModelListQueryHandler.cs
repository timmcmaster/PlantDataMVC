using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.SeedBatch
{
    public class SeedBatchDataModelListQueryHandler : ListQueryHandler<SeedBatchDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedBatchDataModelListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<SeedBatchDataModel>> Handle(ListQuery<SeedBatchDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/SeedBatch";
            IEnumerable<SeedBatchDataModel> fullDataModelList = Enumerable.Empty<SeedBatchDataModel>();

            while (!string.IsNullOrEmpty(uri))
            {
                var response = await _plantDataApiClient.GetAsync<IEnumerable<SeedBatchDataModel>>(uri, cancellationToken).ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else if (response.Success && response.Content != null)
                {
                    var dataModelList = response.Content;

                    // Concatenate page to full list
                    fullDataModelList = (fullDataModelList ?? Enumerable.Empty<SeedBatchDataModel>()).Concat(dataModelList ?? Enumerable.Empty<SeedBatchDataModel>());

                    // if we haven't got all the items, follow paging links (link will be null if no next page)
                    uri = response.LinkInfo?.NextPageLink?.ToString();
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