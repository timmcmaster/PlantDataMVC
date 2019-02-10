using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Controllers.Queries.Genus;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Genus;

namespace PlantDataMVC.UI.Handlers.Views.Genus
{
    public class GenusShowViewModelHandler : IViewHandler<GenusShowQuery,GenusShowViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public GenusShowViewModelHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GenusShowViewModel> HandleAsync(GenusShowQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/Genus/" + query.Id).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<GenusDto>(content);

                var model = Mapper.Map<GenusDto,GenusShowViewModel>(dto);
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