using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class PagingHelper
    {
        public static NameValueCollection GetPaginationHeaders<T>(IQueryable<T> source, string routeName, object routeValues, int page, int pageSize)
        {
            const string linkHeaderTemplate = "<%0>; rel=\"%1\"";

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

            // TODO: Get links using routeValues etc
            // Get next and previous pages, copying query params from current request
            var urlHelper = new UrlHelper(request);

            var prevLink = page > 1 ? urlHelper.Link() : "";
            var nextLink = page < totalCount ? urlHelper.Link();

            List<string> links = new List<string>();
            links.Add(string.Format(linkHeaderTemplate, prevLink,"prev"));
            links.Add(string.Format(linkHeaderTemplate, nextLink, "next"));

            var headers = new NameValueCollection
            {
                {"Link", String.Join(",", links)},
                { "X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeaderContent)}
            };

        }

        public static ICollection<HtmlString> GetPaginationLinkHeader<T>(IQueryable<T> queryable, string baseUri)
        {

        }
    }
}