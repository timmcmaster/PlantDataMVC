﻿using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.Transaction;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels.Transaction;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Transaction
{
    public class DeleteQueryHandler : IQueryHandler<DeleteQuery, TransactionDeleteViewModel>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteQueryHandler(IHttpClientFactory httpClientFactory)
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