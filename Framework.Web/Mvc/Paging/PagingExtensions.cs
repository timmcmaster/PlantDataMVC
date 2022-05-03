using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Framework.Web.Mvc.Paging
{
    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement wrappers for RenderAction method
    /// </summary>
    public static class PagingExtensions
    {
        public static MvcHtmlString PagingLinksFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
                                                                      Expression<Func<TModel, TProperty>>
                                                                          expr) //where TModel : IPageable
        {
            var model = helper.ViewData.Model as IPageable;

            //ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);

            var prevLink = new MvcHtmlString("");
            var separator = new MvcHtmlString("");
            var nextLink = new MvcHtmlString("");

            if (model != null)
            {
                if (model.HasPreviousPage)
                {
                    var routeDataPrev = new RouteValueDictionary
                        {{"page", model.PageNumber - 1}, {"pageSize", model.PageSize}};

                    routeDataPrev.AddQueryStringParameters();

                    prevLink = helper.ActionLink("< Previous Page",
                                                 helper.ViewContext.RouteData.Values["action"].ToString(),
                                                 routeDataPrev);
                }

                if (model.HasPreviousPage && model.HasNextPage)
                {
                    var builder = new TagBuilder("text");
                    builder.InnerHtml = "&nbsp;|&nbsp;";

                    separator = MvcHtmlString.Create(builder.ToString());
                }

                if (model.HasNextPage)
                {
                    var routeDataNext = new RouteValueDictionary
                        {{"page", model.PageNumber + 1}, {"pageSize", model.PageSize}};

                    routeDataNext.AddQueryStringParameters();

                    nextLink = helper.ActionLink("Next Page >",
                                                 helper.ViewContext.RouteData.Values["action"].ToString(),
                                                 routeDataNext);
                }
            }

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("pagination");
            divBuilder.InnerHtml = prevLink.ToHtmlString() + separator.ToHtmlString() + nextLink.ToHtmlString();

            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}