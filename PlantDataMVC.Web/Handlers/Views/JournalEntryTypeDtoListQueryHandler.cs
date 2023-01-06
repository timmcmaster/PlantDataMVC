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
    public class JournalEntryTypeDtoListQueryHandler : ListQueryHandler<JournalEntryTypeDataModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public JournalEntryTypeDtoListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<JournalEntryTypeDataModel>> Handle(ListQuery<JournalEntryTypeDataModel> query, CancellationToken cancellationToken)
        {
            bool success = true;
            string? uri = "api/JournalEntryType";
            IEnumerable<JournalEntryTypeDataModel> fullDtoList = Enumerable.Empty<JournalEntryTypeDataModel>();

            while (!String.IsNullOrEmpty(uri))
            {
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<JournalEntryTypeDataModel>>(content);

                    // Concatenate page to full list
                    fullDtoList = (fullDtoList ?? Enumerable.Empty<JournalEntryTypeDataModel>()).Concat(dtoList ?? Enumerable.Empty<JournalEntryTypeDataModel>());

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