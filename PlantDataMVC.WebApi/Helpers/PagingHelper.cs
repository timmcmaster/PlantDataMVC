using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Http.Routing;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class PagingHelper
    {
        public static NameValueCollection GetPaginationHeaders<T>(UrlHelper urlHelper, IQueryable<T> source, string routeName,
            object routeValues, int page, int pageSize)
        {
            const string linkHeaderTemplate = "<{0}>; rel=\"{1}\"";

            var totalCount = source.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // create anonymous pagination header object
            var paginationHeaderContent = new
            {
                page = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages
            };

            var linkBuilder = new PageLinkBuilder(urlHelper,routeName,routeValues,page,pageSize,totalPages);

            List<string> links = new List<string>();

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
                { "X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeaderContent)}
            };

            return headers;
        }
    }
}