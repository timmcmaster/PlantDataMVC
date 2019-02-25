using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI.Handlers.Views.SeedBatch
{
    public class SeedBatchDtoListQueryHandler : ListQueryHandler<SeedBatchDto>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SeedBatchDtoListQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<IEnumerable<SeedBatchDto>> HandleAsync(ListQuery<SeedBatchDto> query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var uri = "api/SeedBatch";
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            //var httpResponse = await httpClient.GetAsync(uri).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SeedBatchDto>>(content);

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