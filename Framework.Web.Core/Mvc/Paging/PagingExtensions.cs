using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace Framework.Web.Core.Mvc.Paging
{
    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement wrappers for RenderAction method
    /// </summary>
    public static class PagingExtensions
    {
        public static HtmlString PagingLinksFor<TModel, TProperty>(this IHtmlHelper<TModel> helper,
                                                                      Expression<Func<TModel, TProperty>>
                                                                          expr) //where TModel : IPageable
        {
            var model = helper.ViewData.Model as IPageable;

            //ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);

            IHtmlContent prevLink = new HtmlString("");
            IHtmlContent separator = new HtmlString("");
            IHtmlContent nextLink = new HtmlString("");

            if (model != null)
            {
                if (model.HasPreviousPage)
                {
                    var routeDataPrev = new RouteValueDictionary
                        {{"page", model.PageNumber - 1}, {"pageSize", model.PageSize}};

                    routeDataPrev.AddQueryStringParameters();

                    prevLink = helper.ActionLink("< Previous Page", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataPrev);
                }

                if (model.HasPreviousPage && model.HasNextPage)
                {
                    var builder = new TagBuilder("text");
                    builder.InnerHtml.AppendHtml("&nbsp;|&nbsp;");

                    separator = new HtmlString(builder.ToString());
                }

                if (model.HasNextPage)
                {
                    var routeDataNext = new RouteValueDictionary
                        {{"page", model.PageNumber + 1}, {"pageSize", model.PageSize}};

                    routeDataNext.AddQueryStringParameters();

                    nextLink = helper.ActionLink("Next Page >", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataNext);
                }
            }

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("pagination");
            divBuilder.InnerHtml.AppendHtml(prevLink);
            divBuilder.InnerHtml.AppendHtml(separator);
            divBuilder.InnerHtml.AppendHtml(nextLink);

            return new HtmlString(divBuilder.ToString());
        }
    }
}