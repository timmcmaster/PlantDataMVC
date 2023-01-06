﻿using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using PlantDataMVC.Web.Controllers.Queries;
using PlantDataMVC.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                    var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                    var dataModelList = JsonConvert.DeserializeObject<IEnumerable<SpeciesDataModel>>(content);
                    
                    // Concatenate page to full list
                    fullDataModelList = (fullDataModelList ?? Enumerable.Empty<SpeciesDataModel>()).Concat(dataModelList ?? Enumerable.Empty<SpeciesDataModel>());

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