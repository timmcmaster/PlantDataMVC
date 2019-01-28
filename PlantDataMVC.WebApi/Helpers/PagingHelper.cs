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
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages
            };

            // Get next and previous pages, with some routeValues passed in from current request
            Uri firstLink = null;
            Uri lastLink = null;
            Uri prevLink = null;
            Uri nextLink = null;

            firstLink = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"page", 1},
                {"pageSize", pageSize}
            }));
            lastLink = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"page", totalPages},
                {"pageSize", pageSize}
            }));
            if (page > 1)
            {
                prevLink = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                    {"page", page - 1},
                    {"pageSize", pageSize}
                }));
            }

            if (page < totalPages)
            {
                nextLink = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                    {"page", page + 1},
                    {"pageSize", pageSize}
                }));
            }


            List<string> links = new List<string>();
            if (firstLink != null)
            {
                links.Add(string.Format(linkHeaderTemplate, firstLink, "first"));
            }
            if (prevLink != null)
            {
                links.Add(string.Format(linkHeaderTemplate, prevLink, "prev"));
            }

            if (nextLink != null)
            {
                links.Add(string.Format(linkHeaderTemplate, nextLink, "next"));
            }
            if (lastLink != null)
            {
                links.Add(string.Format(linkHeaderTemplate, lastLink, "last"));
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