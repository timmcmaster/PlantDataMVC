using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Web.Core.Mvc.Sorting
{
    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement column headers for tables.
    /// </summary>
    public static class SortingExtensions
    {
        // TODO: Perhaps should be TagHelpers? https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-6.0

        public static HtmlString ColumnHeaderFor<TModel, TProperty>(this IHtmlHelper<TModel> helper,
                                                                       Expression<Func<TModel, TProperty>> expr)
        {
            var expressionProvider = new ModelExpressionProvider(helper.MetadataProvider);
            var modelExpression = expressionProvider.CreateModelExpression(helper.ViewData, expr);
            var metadata = modelExpression.Metadata;


            if (helper.ViewData.Model is ISortable)
            {
                return SortableColumnHeaderFor(helper, expr);
            }

            return new HtmlString(metadata.GetDisplayName());
        }

        public static HtmlString SortableColumnHeaderFor<TModel, TProperty>(this IHtmlHelper<TModel> helper,
                                                                               Expression<Func<TModel, TProperty>>
                                                                                   expr) //where TModel : ISortable
        {
            var model = helper.ViewData.Model as ISortable;

            var expressionProvider = new ModelExpressionProvider(helper.MetadataProvider);
            var modelExpression = expressionProvider.CreateModelExpression(helper.ViewData, expr);
            var metadata = modelExpression.Metadata;

            if (model == null)
            {
                return new HtmlString(metadata.GetDisplayName());
            }

            // check if current sort is descending on current column
            var isDescending = string.CompareOrdinal(model.SortBy, metadata.PropertyName) == 0 &&
                               model.SortAscending;

            var routeData = new RouteValueDictionary
                {{"sortBy", metadata.PropertyName}, {"ascending", !isDescending}};

            // Add in the querystring parameters *except* for the paging ones (as sorting should send us back to the first page of data)
            routeData.AddQueryStringParameters().ExceptFor("page", "pageSize");

            var htmlAttributes = new Dictionary<string, object>();

            if (string.CompareOrdinal(model.SortBy, metadata.PropertyName) == 0)
            {
                htmlAttributes.Add("class", model.SortAscending ? "sortAsc" : "sortDesc");
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

            return new HtmlString(builder.ToString());
        }
    }
}