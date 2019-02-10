using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Plant;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.Plant;

namespace PlantDataMVC.UI.Handlers.Views.Plant
{
    public class EditQueryHandler : IQueryHandler<EditQuery, PlantEditViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public EditQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PlantEditViewModel> HandleAsync(EditQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var httpResponse = await httpClient.GetAsync("api/Species/" + query.Id).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SpeciesDto>(content);

                var model = Mapper.Map<SpeciesDto, PlantEditViewModel>(dto);
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