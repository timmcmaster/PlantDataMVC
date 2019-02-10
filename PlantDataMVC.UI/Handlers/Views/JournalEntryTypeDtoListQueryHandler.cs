using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;

namespace PlantDataMVC.UI.Handlers.Views
{
    public class JournalEntryTypeDtoListQueryHandler : ListQueryHandler<JournalEntryTypeDto>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public JournalEntryTypeDtoListQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async Task<IEnumerable<JournalEntryTypeDto>> HandleAsync(ListQuery<JournalEntryTypeDto> query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);

            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/JournalEntryType").ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<JournalEntryTypeDto>>(content);

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