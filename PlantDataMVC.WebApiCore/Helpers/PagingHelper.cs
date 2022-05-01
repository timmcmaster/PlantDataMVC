using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PlantDataMVC.WebApiCore.Helpers
{
    public static class PagingHelper
    {
        public static IHeaderDictionary GetPaginationHeaders(IUrlHelper urlHelper, int sourceCount,
                                                                  string routeName,
                                                                  object routeValues, int page, int pageSize)
        {
            const string linkHeaderTemplate = "<{0}>; rel=\"{1}\"";

            var totalCount = sourceCount;
            var totalPages = (int) Math.Ceiling((double) totalCount / pageSize);

            // create anonymous pagination header object
            var paginationHeaderContent = new
            {
                page,
                pageSize,
                totalCount,
                totalPages
            };

            var linkBuilder = new PageLinkBuilder(urlHelper, routeName, routeValues, page, pageSize, totalPages);

            var links = new List<string>();

            if (linkBuilder.FirstPage != null)
            {
                links.Add(string.Format(linkHeaderTemplate, linkBuilder.FirstPage, "first"));
            }

            if (linkBuilder.PreviousPage != null)
            {
                links.Add(string.Format(linkHeaderTemplate, linkBuilder.PreviousPage, "prev"));
            }

            if (linkBuilder.NextPage != null)
            {
                links.Add(string.Format(linkHeaderTemplate, linkBuilder.NextPage, "next"));
            }

            if (linkBuilder.LastPage != null)
            {
                links.Add(string.Format(linkHeaderTemplate, linkBuilder.LastPage, "last"));
            }

            var headers = new HeaderDictionary();
            headers.Append("Link", string.Join(",", links));
            headers.Append("X-Pagination", JsonConvert.SerializeObject(paginationHeaderContent));

            return headers;
        }
    }
}