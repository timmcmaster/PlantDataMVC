using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.SeedTray;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.SeedTray;

namespace PlantDataMVC.UI.Handlers.Views.SeedTray
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, SeedTrayDeleteViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public DeleteQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SeedTrayDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var uri = "api/SeedTray/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SeedTrayDto>(content);

                var model = Mapper.Map<SeedTrayDto, SeedTrayDeleteViewModel>(dto);
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