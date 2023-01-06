﻿using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.UICore.Controllers.Queries;
using PlantDataMVC.UICore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Genus
{
    public class GenusDtoListQueryHandler : ListQueryHandler<GenusDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public GenusDtoListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<GenusDataModel>> Handle(ListQuery<GenusDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/Genus";
            IEnumerable<GenusDataModel> fullDtoList = Enumerable.Empty<GenusDataModel>();

            while (!String.IsNullOrEmpty(uri))
            {
                var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                    var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                    var dtoList = JsonConvert.DeserializeObject<IEnumerable<GenusDataModel>>(content);

                    // Concatenate page to full list
                    fullDtoList = (fullDtoList ?? Enumerable.Empty<GenusDataModel>()).Concat(dtoList ?? Enumerable.Empty<GenusDataModel>());

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
                return fullDtoList;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}