using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Genus;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.Genus;

namespace PlantDataMVC.UI.Handlers.Views.Genus
{
    public class EditQueryHandler : IQueryHandler<EditQuery,GenusEditViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public EditQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GenusEditViewModel> HandleAsync(EditQuery query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var uri = "api/Genus/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<GenusDto>(content);
                var model = Mapper.Map<GenusDto, GenusEditViewModel>(dto);
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