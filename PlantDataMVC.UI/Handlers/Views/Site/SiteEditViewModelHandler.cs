using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Controllers.Queries.Site;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;
using PlantDataMVC.UI.Models.ViewModels.Site;

namespace PlantDataMVC.UI.Handlers.Views.Site
{
    public class SiteEditViewModelHandler : IViewHandler<SiteEditQuery, SiteEditViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public SiteEditViewModelHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SiteEditViewModel> HandleAsync(SiteEditQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/Site/" + query.Id).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SiteDto>(content);

                var model = Mapper.Map<SiteDto, SiteEditViewModel>(dto);
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