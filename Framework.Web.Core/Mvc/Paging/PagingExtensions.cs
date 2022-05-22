using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace Framework.Web.Core.Mvc.Paging
{
    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement PagingLinks
    /// </summary>
    public static class PagingExtensions
    {
        public static HtmlString PagingLinksFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expr) //where TModel : IPageable
        {
            //ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);
            var sw = new StringWriter();

            var model = helper.ViewData.Model as IPageable;
            var currentRequest = helper.ViewContext.HttpContext.Request;

            IHtmlContent prevLink = new HtmlString("");
            IHtmlContent separator = new HtmlString("");
            IHtmlContent nextLink = new HtmlString("");

            if (model != null)
            {
                if (model.HasPreviousPage)
                {
                    var routeDataPrev = new RouteValueDictionary
                        {{"page", model.PageNumber - 1}, {"pageSize", model.PageSize}};

                    routeDataPrev.AddQueryStringParameters(currentRequest);

                    prevLink = helper.ActionLink("< Previous Page", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataPrev);
                }

                if (model.HasPreviousPage && model.HasNextPage)
                {
                    var builder = new TagBuilder("text");
                    builder.InnerHtml.AppendHtml("&nbsp;|&nbsp;");
                    builder.WriteTo(sw, HtmlEncoder.Default);

                    separator = new HtmlString(sw.ToString());
                }

                if (model.HasNextPage)
                {
                    var routeDataNext = new RouteValueDictionary
                        {{"page", model.PageNumber + 1}, {"pageSize", model.PageSize}};

                    routeDataNext.AddQueryStringParameters(currentRequest);

                    nextLink = helper.ActionLink("Next Page >", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataNext);
                }
            }

            sw.GetStringBuilder().Clear();

            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("pagination");
            divBuilder.InnerHtml.AppendHtml(prevLink);
            divBuilder.InnerHtml.AppendHtml(separator);
            divBuilder.InnerHtml.AppendHtml(nextLink);
            divBuilder.WriteTo(sw, HtmlEncoder.Default);

            return new HtmlString(sw.ToString());
        }
    }
}