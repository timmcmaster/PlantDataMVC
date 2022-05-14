using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.PlantStock;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.PlantStock
{
    public class ShowQueryHandler : IQueryHandler<ShowQuery, PlantStockShowViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public ShowQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<PlantStockShowViewModel> HandleAsync(ShowQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/PlantStock/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<PlantStockDto>(content);

                var model = Mapper.Map<PlantStockDto, PlantStockShowViewModel>(dto);
                return model;
            }
            else
            {
                // TODO: better way needed to handle failure response
                return null;
            }
        }
    }
}