using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace Framework.Web.Mvc.Paging
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
            var pageLinkHtmlAttributes = new Dictionary<string, object>
                    {
                        { "class", "page-link" }
                    };


            var pageHtmlList = new List<IHtmlContent>();

            if (model != null)
            {
                // Previous link
                var listItemBuilder = new TagBuilder("li");

                if (model.HasPreviousPage)
                {
                    var routeDataPrev = new RouteValueDictionary
                        {{"page", model.PageNumber - 1}, {"pageSize", model.PageSize}};

                    routeDataPrev.AddQueryStringParameters(currentRequest);
                    var prevLink = helper.ActionLink("Previous", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataPrev, pageLinkHtmlAttributes);

                    listItemBuilder.AddCssClass("page-item");
                    listItemBuilder.InnerHtml.AppendHtml(prevLink);
                }
                else
                {
                    var prevLink = new TagBuilder("span");
                    prevLink.AddCssClass("page-link");
                    prevLink.InnerHtml.Append("Previous");
                    listItemBuilder.AddCssClass("page-item disabled");
                    listItemBuilder.InnerHtml.AppendHtml(prevLink);
                }
                pageHtmlList.Add(listItemBuilder);


                // Add any page links in between
                for (int i = 1; i <= model.TotalPages; i++)
                {
                    listItemBuilder = new TagBuilder("li");

                    if (i == model.PageNumber)
                    {
                        var pageLink = new TagBuilder("span");
                        pageLink.AddCssClass("page-link");
                        pageLink.InnerHtml.Append(i.ToString());
                        listItemBuilder.AddCssClass("page-item active");
                        listItemBuilder.InnerHtml.AppendHtml(pageLink);
                    }
                    else
                    {
                        var routeData = new RouteValueDictionary { { "page", i}, { "pageSize", model.PageSize}};

                        routeData.AddQueryStringParameters(currentRequest);

                        var pageLink = helper.ActionLink(i.ToString(), helper.ViewContext.RouteData.Values["action"].ToString(), routeData, pageLinkHtmlAttributes);

                        listItemBuilder.AddCssClass("page-item");
                        listItemBuilder.InnerHtml.AppendHtml(pageLink);
                    }
                    pageHtmlList.Add(listItemBuilder);
                }

                // Next link
                listItemBuilder = new TagBuilder("li");

                if (model.HasNextPage)
                {
                    var routeDataNext = new RouteValueDictionary
                        {{"page", model.PageNumber + 1}, {"pageSize", model.PageSize}};

                    routeDataNext.AddQueryStringParameters(currentRequest);

                    var nextLink = helper.ActionLink("Next", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataNext, pageLinkHtmlAttributes);

                    listItemBuilder.AddCssClass("page-item");
                    listItemBuilder.InnerHtml.AppendHtml(nextLink);
                }
                else
                {
                    var nextLink = new TagBuilder("span");
                    nextLink.AddCssClass("page-link");
                    nextLink.InnerHtml.Append("Next");
                    listItemBuilder.AddCssClass("page-item disabled");
                    listItemBuilder.InnerHtml.AppendHtml(nextLink);
                }
                pageHtmlList.Add(listItemBuilder);
            }

            sw.GetStringBuilder().Clear();

            var navBuilder = new TagBuilder("nav");
            navBuilder.Attributes.Add("aria-label", "Page navigation");

            var listBuilder = new TagBuilder("ul");
            listBuilder.AddCssClass("pagination");

            foreach (var item in pageHtmlList)
            {
                listBuilder.InnerHtml.AppendHtml(item);
            }

            navBuilder.InnerHtml.AppendHtml(listBuilder);

            navBuilder.WriteTo(sw, HtmlEncoder.Default);

            return new HtmlString(sw.ToString());
        }
    }
}