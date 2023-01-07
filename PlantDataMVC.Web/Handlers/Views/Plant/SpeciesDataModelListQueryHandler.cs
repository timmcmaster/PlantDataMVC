using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Plant
{
    public class SpeciesDataModelListQueryHandler : ListQueryHandler<SpeciesDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SpeciesDataModelListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<SpeciesDataModel>> Handle(ListQuery<SpeciesDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/Species";
            IEnumerable<SpeciesDataModel> fullDataModelList = Enumerable.Empty<SpeciesDataModel>();

            while (!String.IsNullOrEmpty(uri))
            {
                var response = await _plantDataApiClient.GetAsync<IEnumerable<SpeciesDataModel>>(uri, cancellationToken).ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else if (response.Success && response.Content != null)
                {
                    //var apiPagingInfo = response.PagingInfo;

                    var dataModelList = response.Content;

                    // Concatenate page to full list
                    fullDataModelList = (fullDataModelList ?? Enumerable.Empty<SpeciesDataModel>()).Concat(dataModelList ?? Enumerable.Empty<SpeciesDataModel>());

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