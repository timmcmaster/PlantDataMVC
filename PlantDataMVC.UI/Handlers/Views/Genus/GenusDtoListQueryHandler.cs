﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI.Handlers.Views.Genus
{
    public class GenusDtoListQueryHandler : ListQueryHandler<GenusDto>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public GenusDtoListQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<IEnumerable<GenusDto>> HandleAsync(ListQuery<GenusDto> query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var uri = "api/Genus";
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<GenusDto>>(content);

                return dtoList;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}