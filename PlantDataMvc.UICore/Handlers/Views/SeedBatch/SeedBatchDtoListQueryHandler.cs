using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries;
using PlantDataMVC.UICore.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedBatch
{
    public class SeedBatchDtoListQueryHandler : ListQueryHandler<SeedBatchDto>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public SeedBatchDtoListQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public override async Task<IEnumerable<SeedBatchDto>> HandleAsync(ListQuery<SeedBatchDto> query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedBatch";
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            //var httpResponse = await _plantDataApiClient.GetAsync(uri).ConfigureAwait(false);

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