using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace Framework.Web.Mvc.Sorting
{
    public enum SortDirection
    {
        Default,
        Ascending,
        Descending
    }

    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement column headers for tables.
    /// </summary>
    public static class SortingExtensions
    {
        // TODO: Perhaps should be TagHelpers? https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-6.0

        public static IHtmlContent ColumnHeaderFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expr, bool allowSorting = true)
        {
            var expressionProvider = new ModelExpressionProvider(helper.MetadataProvider);
            var modelExpression = expressionProvider.CreateModelExpression(helper.ViewData, expr);
            var metadata = modelExpression.Metadata;


            if ((helper.ViewData.Model is ISortable) && allowSorting)
            {
                return SortableColumnHeaderFor(helper, expr);
            }

            return new HtmlString(metadata.GetDisplayName());
        }

        public static IHtmlContent SortableColumnHeaderFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expr) //where TModel : ISortable
        {
            var model = helper.ViewData.Model as ISortable;
            var currentRequest = helper.ViewContext.HttpContext.Request;

            var expressionProvider = new ModelExpressionProvider(helper.MetadataProvider);
            var modelExpression = expressionProvider.CreateModelExpression(helper.ViewData, expr);
            var metadata = modelExpression.Metadata;

            if (model == null)
            {
                return new HtmlString(metadata.GetDisplayName());
            }


            // Set CSS only based on current state
            var htmlAttributes = new Dictionary<string, object>();
            if (string.CompareOrdinal(model.SortBy, metadata.PropertyName) == 0)
            {
                if (currentRequest.Query["ascending"].Count > 0)
                {
                    if (model.SortAscending)
                    {
                        htmlAttributes.Add("class", "sortAsc");
                    }
                    else
                    {
                        htmlAttributes.Add("class", "sortDesc");
                    }
                }
            }

            // Set link to sort by this coluimn regardless of current sort
            // Sort rotation should be (1.default 2.ascending 3.descending 4.default)
            var routeData = new RouteValueDictionary();

            // Add in the querystring parameters *except* for the paging ones (as sorting should send us back to the first page of data)
            routeData.AddQueryStringParameters(currentRequest).ExceptFor("sortBy", "ascending", "page", "pageSize");

            // if no sortAscending param in currentRequest
            if (currentRequest.Query["ascending"].Count == 0)
            {
                // Link for ascending
                routeData.Add("sortBy", metadata.PropertyName);
                routeData.Add("ascending", true);
            }
            else
            {
                if (model.SortAscending)
                {
                    // Link for descending
                    routeData.Add("sortBy", metadata.PropertyName);
                    routeData.Add("ascending", false);
                }
                else
                {
                    // Link for default
                }
            }

            var actionLink = helper.ActionLink(
                metadata.GetDisplayName(), // Link Text
                helper.ViewContext.RouteData.Values["action"].ToString(), // Action
                routeData, // Route data
                htmlAttributes // HTML attributes to apply to hyperlink
            );

            var builder = new TagBuilder("div");
            builder.AddCssClass("sorting");
            builder.InnerHtml.AppendHtml(actionLink);
            
            var sw = new StringWriter();
            builder.WriteTo(sw, HtmlEncoder.Default);

            var str = sw.ToString();
            return new HtmlString(str);
        }
    }
}