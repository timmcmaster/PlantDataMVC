using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries;
using PlantDataMVC.UICore.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Plant
{
    public class SpeciesDtoListQueryHandler : ListQueryHandler<SpeciesDto>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SpeciesDtoListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<SpeciesDto>> HandleAsync(ListQuery<SpeciesDto> query, CancellationToken cancellationToken)
        {
            var uri = "api/Species";
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<SpeciesDto>>(content);

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