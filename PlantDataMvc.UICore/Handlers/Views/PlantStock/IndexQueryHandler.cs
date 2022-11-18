using AutoMapper;
using Framework.Web.Core.Views;
using Newtonsoft.Json;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.UICore.Controllers.Queries.PlantStock;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels;
using PlantDataMVC.UICore.Models.ViewModels.PlantStock;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.PlantStock
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<PlantStockListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<PlantStockListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query string
            var requestUri = "api/PlantStock?page=" + query.Page + "&pageSize=" + query.PageSize;

            // add sorting if it maps ok
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var apiSortField = MapSortField(query.SortBy);
                if (!string.IsNullOrEmpty(apiSortField))
                {
                    var sortString = ApiSorting.CreateSortString(apiSortField, query.SortAscending);
                    requestUri = sortString == "" ? requestUri : requestUri + "&sort=" + sortString;
                }
            }

            var httpResponse = await _plantDataApiClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                ApiPagingInfo apiPagingInfo = HeaderParser.FindAndParsePagingInfo(httpResponse.Headers);
                LinkHeader linkInfo = HeaderParser.FindAndParseLinkInfo(httpResponse.Headers);

                var dtoList = JsonConvert.DeserializeObject<IEnumerable<PlantStockDto>>(content);
                List<PlantStockListViewModel> modelList =
                    _mapper.Map<IEnumerable<PlantStockDto>, List<PlantStockListViewModel>>(dtoList);

                var model = new ListViewModelStatic<PlantStockListViewModel>(modelList,
                                                                             apiPagingInfo.page,
                                                                             apiPagingInfo.pageSize,
                                                                             apiPagingInfo.totalCount,
                                                                             query.SortBy,
                                                                             query.SortAscending);

                return model;
            }

            // TODO: better way needed to handle failure response
            return null;
        }

        /// <summary>
        /// Maps the sort field from display field column to dto field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(PlantStockListViewModel.Id))
            {
                sortField = nameof(PlantStockDto.Id);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.ProductTypeName))
            {
                sortField = nameof(PlantStockDto.ProductTypeName);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.QuantityInStock))
            {
                sortField = nameof(PlantStockDto.QuantityInStock);
            }
            else if (querySortBy == nameof(PlantStockListViewModel.SpeciesBinomial))
            {
                sortField = $"{nameof(PlantStockDto.GenusName)},{nameof(PlantStockDto.SpeciesName)}";
            }
            else if (querySortBy == nameof(PlantStockListViewModel.SpeciesId))
            {
                sortField = nameof(PlantStockDto.SpeciesId);
            }

            return sortField;
        }
    }
}