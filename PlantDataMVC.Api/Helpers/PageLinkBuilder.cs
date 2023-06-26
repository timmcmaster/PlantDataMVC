using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

namespace PlantDataMVC.Api.Helpers
{
    public class PageLinkBuilder
    {
        public PageLinkBuilder(IUrlHelper urlHelper, string routeName, object routeValues, int page, int pageSize,
                               int totalPages)
        {
            // Get next and previous pages, with some routeValues passed in from current request
            var firstPageRvd = new RouteValueDictionary(routeValues) { { "page", 1 }, { "pageSize", pageSize } };
            var firstLink = urlHelper.Link(routeName, firstPageRvd);
            if (firstLink != null)
            {
                FirstPage = new Uri(firstLink);
            }

            var lastPageRvd = new RouteValueDictionary(routeValues) { { "page", totalPages }, { "pageSize", pageSize } };
            var lastLink = urlHelper.Link(routeName, lastPageRvd);
            if (lastLink != null)
            {
                LastPage = new Uri(lastLink);
            }

            if (page > 1)
            {
                var prevPageRvd = new RouteValueDictionary(routeValues) { { "page", page - 1 }, { "pageSize", pageSize } };
                var prevLink = urlHelper.Link(routeName, prevPageRvd);
                if (prevLink != null)
                {
                    PreviousPage = new Uri(prevLink);
                }
            }

            if (page < totalPages)
            {
                var nextPageRvd = new RouteValueDictionary(routeValues) { { "page", page + 1 }, { "pageSize", pageSize } };
                var nextLink = urlHelper.Link(routeName, nextPageRvd);
                if (nextLink != null)
                {
                    NextPage = new Uri(nextLink);
                }
            }
        }

        public Uri? FirstPage { get; }
        public Uri? LastPage { get; }
        public Uri? PreviousPage { get; }
        public Uri? NextPage { get; }
    }
}