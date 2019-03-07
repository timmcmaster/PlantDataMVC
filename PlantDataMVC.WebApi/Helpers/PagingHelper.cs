using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Http.Routing;
using Newtonsoft.Json;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class PagingHelper
    {
        public static NameValueCollection GetPaginationHeaders(UrlHelper urlHelper, int sourceCount,
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

            var headers = new NameValueCollection
            {
                // TODO: Implement as (proposed) RFC8288 https://httpwg.org/specs/rfc8288.html
                {"Link", string.Join(",", links)},
                {"X-Pagination", JsonConvert.SerializeObject(paginationHeaderContent)}
            };

            return headers;
        }
    }
}