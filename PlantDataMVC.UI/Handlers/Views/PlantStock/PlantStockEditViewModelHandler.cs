using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Controllers.Queries.PlantStock;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.PlantStock;

namespace PlantDataMVC.UI.Handlers.Views.PlantStock
{
    public class PlantStockEditViewModelHandler : IViewHandler<PlantStockEditQuery,PlantStockEditViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public PlantStockEditViewModelHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PlantStockEditViewModel> HandleAsync(PlantStockEditQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/PlantStock/" + query.Id).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<PlantStockDto>(content);

                var model = Mapper.Map<PlantStockDto, PlantStockEditViewModel>(dto);
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