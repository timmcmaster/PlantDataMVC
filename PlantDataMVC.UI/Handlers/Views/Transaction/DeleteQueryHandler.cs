using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries.Transaction;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels.Transaction;

namespace PlantDataMVC.UI.Handlers.Views.Transaction
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery,TransactionDeleteViewModel>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public DeleteQueryHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TransactionDeleteViewModel> HandleAsync(DeleteQuery query, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);
            var uri = "api/JournalEntries/" + query.Id;
            var httpResponse = await httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dto = JsonConvert.DeserializeObject<JournalEntryDto>(content);

                var model = Mapper.Map<JournalEntryDto, TransactionDeleteViewModel>(dto);
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