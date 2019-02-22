using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.SeedBatch;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.SeedBatch;

namespace PlantDataMVC.UI.Handlers.Views.SeedBatch
{
    public class EditQueryHandler : IQueryHandler<EditQuery, SeedBatchEditViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public EditQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SeedBatchEditViewModel> HandleAsync(EditQuery query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            // todo: if not null client
            var uri = "api/SeedBatch/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<SeedBatchDto>(content);

                var model = Mapper.Map<SeedBatchDto, SeedBatchEditViewModel>(dto);
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