using AutoMapper;
using Framework.Web.Views;
using Newtonsoft.Json;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.UICore.Controllers.Queries.Plant;
using PlantDataMVC.UICore.Helpers;
using PlantDataMVC.UICore.Models.ViewModels;
using PlantDataMVC.UICore.Models.ViewModels.Plant;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.UICore.Handlers.Views.Plant
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, ListViewModelStatic<PlantListViewModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<ListViewModelStatic<PlantListViewModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            // Get paging part of query
            // TODO: really want to sort by genus name and species name (if showing details by plant)
            var requestUri = "api/Species?page=" + query.Page + "&pageSize=" + query.PageSize;

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

                var dataModelList = JsonConvert.DeserializeObject<IEnumerable<SpeciesDataModel>>(content);
                List<PlantListViewModel> modelList =
                    _mapper.Map<IEnumerable<SpeciesDataModel>, List<PlantListViewModel>>(dataModelList);

                var model = new ListViewModelStatic<PlantListViewModel>(modelList, apiPagingInfo.page,
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
        /// Maps the sort field from display field column to dataModel field as used by API
        /// </summary>
        /// <param name="querySortBy">The query sort by.</param>
        /// <returns></returns>
        private string MapSortField(string querySortBy)
        {
            var sortField = "";

            // TODO: Got to be a more rigorous way to convert columns back to API fields
            // supplied sortBy field should belong to display object (as it is generated from model metadata)
            if (querySortBy == nameof(PlantListViewModel.Id))
            {
                sortField = nameof(SpeciesDataModel.Id);
            }
            else if (querySortBy == nameof(PlantListViewModel.Binomial))
            {
                sortField = $"{nameof(SpeciesDataModel.GenusName)},{nameof(SpeciesDataModel.SpecificName)}";
            }
            else if (querySortBy == nameof(PlantListViewModel.CommonName))
            {
                sortField = nameof(SpeciesDataModel.CommonName);
            }

            return sortField;
        }
    }
}