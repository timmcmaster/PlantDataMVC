using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

namespace PlantDataMVC.WebApiCore.Helpers
{
    public class PageLinkBuilder
    {
        public PageLinkBuilder(IUrlHelper urlHelper, string routeName, object routeValues, int page, int pageSize,
                               int totalPages)
        {
            // Get next and previous pages, with some routeValues passed in from current request
            var firstPageRvd = new RouteValueDictionary(routeValues) { { "page", 1 }, { "pageSize", pageSize } };
            FirstPage = new Uri(urlHelper.Link(routeName, firstPageRvd));

            var lastPageRvd = new RouteValueDictionary(routeValues) { { "page", totalPages }, { "pageSize", pageSize } };
            LastPage = new Uri(urlHelper.Link(routeName, lastPageRvd));

            if (page > 1)
            {
                var prevPageRvd = new RouteValueDictionary(routeValues) { { "page", page - 1 }, { "pageSize", pageSize } };
                PreviousPage = new Uri(urlHelper.Link(routeName, prevPageRvd));
            }

            if (page < totalPages)
            {
                var nextPageRvd = new RouteValueDictionary(routeValues) { { "page", page + 1 }, { "pageSize", pageSize } };
                NextPage = new Uri(urlHelper.Link(routeName, nextPageRvd));
            }
        }

        public Uri FirstPage { get; }
        public Uri LastPage { get; }
        public Uri PreviousPage { get; }
        public Uri NextPage { get; }
    }
}