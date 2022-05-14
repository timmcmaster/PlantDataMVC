using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.SeedTray;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.SeedTray;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.SeedTray
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, SeedTrayDeleteViewModel>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;

        public DeleteQueryHandler(IPlantDataApiClient plantDataApiClient)
        {
            _plantDataApiClient = plantDataApiClient;
        }

        public async Task<SeedTrayDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var uri = "api/SeedTray/" + query.Id;
            var httpResponse = await _plantDataApiClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

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