using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Helpers;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Handlers.Views
{
    // TODO: Check if we need this class
    public class PlantStockTransactionListViewModelHandler : IViewHandler<ListViewModelStatic<PlantStockTransactionListViewModel>,IndexQuery>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlantStockTransactionListViewModelHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<PlantStockTransactionListViewModel>> HandleAsync(IndexQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);

            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/JournalEntries?page=" + query.Page + "&pageSize=" + query.PageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<JournalEntryDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                var modelList = Mapper.Map<IEnumerable<JournalEntryDto>, List<PlantStockTransactionListViewModel>>(dtoList);

                var model = new ListViewModelStatic<PlantStockTransactionListViewModel>(modelList, apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount);

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