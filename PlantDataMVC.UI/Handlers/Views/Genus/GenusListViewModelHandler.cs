using System.Collections.Generic;
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
    public class GenusListViewModelHandler : IViewHandler<GenusIndexQuery,ListViewModelStatic<GenusListViewModel>>
    {
        private readonly IMyHttpClientFactory _httpClientFactory;

        public GenusListViewModelHandler(IMyHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ListViewModelStatic<GenusListViewModel>> HandleAsync(GenusIndexQuery query)
        {
            var httpClient = _httpClientFactory.CreateClient(NamedHttpClients.PlantDataApi);

            // todo: if not null client
            var httpResponse = await httpClient.GetAsync("api/Genus?page=" + query.Page + "&pageSize=" + query.PageSize);

            if (httpResponse.IsSuccessStatusCode)
            {
                string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                var linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<GenusInListDto>>(content);

                // TODO: check to ensure these DTOs map to view model
                var modelList = Mapper.Map<IEnumerable<GenusInListDto>, List<GenusListViewModel>>(dtoList);

                var model = new ListViewModelStatic<GenusListViewModel>(modelList, apiPagingInfo.page, apiPagingInfo.pageSize, apiPagingInfo.totalCount);

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