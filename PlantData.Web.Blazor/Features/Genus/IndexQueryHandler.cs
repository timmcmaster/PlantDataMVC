using AutoMapper;
using Framework.Web.Views;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Blazor.Helpers;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.Genus;
using PlantDataMVC.Api.Models.DataModels;
using PlantDataMVC.Common.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Genus;

public class IndexQueryHandler : IQueryHandler<IndexQuery, GridDataModel<GenusGridModel>>
{
    private readonly IPlantDataApiClient _plantDataApiClient;
    private readonly IMapper _mapper;

    public IndexQueryHandler(IPlantDataApiClient plantDataApiClient, IMapper mapper, IConfiguration configuration)
    {
        _plantDataApiClient = plantDataApiClient;
        _mapper = mapper;
    }

    public async Task<GridDataModel<GenusGridModel>> Handle(IndexQuery query, CancellationToken cancellationToken)
    {
        bool usePaging = query.Page != null && query.PageSize != null;

        // Get paging part of query string
        var baseUri = "api/Genus";
        var queryParams = new Dictionary<string, string?>();
        if (usePaging)
        {
            queryParams.Add("page", query.Page.ToString());
            queryParams.Add("pageSize", query.PageSize.ToString());
        }

        // add sorting if it maps ok
        if (!string.IsNullOrEmpty(query.SortBy))
        {
            var apiSortField = MapSortField(query.SortBy);
            if (!string.IsNullOrEmpty(apiSortField))
            {
                var sortString = ApiSorting.CreateSortString(apiSortField, query.SortAscending);
                if (sortString != "")
                    queryParams.Add("sort", sortString);
            }
        }

        var requestUri = QueryHelpers.AddQueryString(baseUri, queryParams);
        var response = await _plantDataApiClient.GetAsync<IEnumerable<GenusDataModel>>(requestUri, cancellationToken).ConfigureAwait(false);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedAccessException();
        }
        else if (response.Success && response.Content != null)
        {
            var apiPagingInfo = response.PagingInfo;

            var modelList = _mapper.Map<IEnumerable<GenusDataModel>, List<GenusGridModel>>(response.Content);

            // Map to a standard grid data model with paging and sorting data

            var model = new GridDataModel<GenusGridModel>(modelList, apiPagingInfo.Page, apiPagingInfo.PageSize, apiPagingInfo.TotalCount, query.SortBy, query.SortAscending);

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
    private static string MapSortField(string querySortBy)
    {
        var sortField = "";

        // TODO: Got to be a more rigorous way to convert columns back to API fields
        // supplied sortBy field should belong to display object (as it is generated from model metadata)
        if (querySortBy == nameof(GenusGridModel.Id))
        {
            sortField = nameof(GenusDataModel.Id);
        }
        else if (querySortBy == nameof(GenusGridModel.LatinName))
        {
            sortField = nameof(GenusDataModel.LatinName);
        }

        return sortField;
    }
}