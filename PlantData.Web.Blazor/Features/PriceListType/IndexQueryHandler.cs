using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using PlantData.Web.Blazor.Features.PriceListType;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.PriceListType;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.PriceListType
{
    public class IndexQueryHandler : IQueryHandler<IndexQuery, GridDataModel<PriceListTypeGridModel>>
    {
        private readonly IPlantDataApiClient _plantDataApiClient;
        private readonly IMapper _mapper;

        public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper)
        {
            _plantDataApiClient = plantDataApiClient;
            _mapper = mapper;
        }

        public async Task<GridDataModel<PriceListTypeGridModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
        {
            bool usePaging = query.Page != null && query.PageSize != null;

            // Get paging part of query
            var baseUri = "api/PriceListType";
            var queryParams = new Dictionary<string, string?>();
            if (usePaging)
            {
                queryParams.Add("page", query.Page.ToString());
                queryParams.Add("pageSize", query.PageSize.ToString());
            }

            var requestUri = QueryHelpers.AddQueryString(baseUri, queryParams);
            var response = await _plantDataApiClient.GetAsync<IEnumerable<PriceListTypeDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            else if (response.Success && response.Content != null)
            {
                var apiPagingInfo = response.PagingInfo;

                var modelList = _mapper.Map<IEnumerable<PriceListTypeDataModel>, List<PriceListTypeGridModel>>(response.Content);

                var model = new GridDataModel<PriceListTypeGridModel>(
                    modelList,
                    apiPagingInfo.Page, apiPagingInfo.PageSize, apiPagingInfo.TotalCount,
                    query.SortBy, query.SortAscending);

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
