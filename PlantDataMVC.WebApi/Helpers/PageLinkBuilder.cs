using System;
using System.Web.Http.Routing;

namespace PlantDataMVC.WebApi.Helpers
{
    public class PageLinkBuilder
    {
        public PageLinkBuilder(UrlHelper urlHelper, string routeName, object routeValues, int page, int pageSize,
                               int totalPages)
        {
            // Get next and previous pages, with some routeValues passed in from current request
            FirstPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"page", 1},
                {"pageSize", pageSize}
            }));

            LastPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
            {
                {"page", totalPages},
                {"pageSize", pageSize}
            }));

            if (page > 1)
            {
                PreviousPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                    {"page", page - 1},
                    {"pageSize", pageSize}
                }));
            }

            if (page < totalPages)
            {
                NextPage = new Uri(urlHelper.Link(routeName, new HttpRouteValueDictionary(routeValues)
                {
                    {"page", page + 1},
                    {"pageSize", pageSize}
                }));
            }
        }

        public Uri FirstPage { get; }
        public Uri LastPage { get; }
        public Uri PreviousPage { get; }
        public Uri NextPage { get; }
    }
}