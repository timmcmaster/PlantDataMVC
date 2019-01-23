using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Framework.Web.Mvc.Sorting
{
    /// <summary>
    /// Contains Extension methods for HtmlHelper that implement column headers for tables.
    /// </summary>
    public static class SortingExtensions
    {
        public static MvcHtmlString ColumnHeaderFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expr)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);

            if (helper.ViewData.Model is ISortable)
            {
                return SortableColumnHeaderFor(helper, expr);
            }
            else
            {
                return MvcHtmlString.Create(metadata.GetDisplayName());
            }
        }

        public static MvcHtmlString SortableColumnHeaderFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expr) //where TModel : ISortable
        {
            ISortable model = helper.ViewData.Model as ISortable;
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);

            if (model == null)
            {
                return MvcHtmlString.Create(metadata.GetDisplayName());
            }

            // check if current sort is descending on current column
            bool isDescending = string.CompareOrdinal(model.SortBy, metadata.PropertyName) == 0 &&
                                model.SortAscending;

            RouteValueDictionary routeData = new RouteValueDictionary
                {{"sortBy", metadata.PropertyName}, {"ascending", !isDescending}};

            // Add in the querystring parameters *except* for the paging ones (as sorting should send us back to the first page of data)
            routeData.AddQueryStringParameters().ExceptFor("page", "pageSize");

            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            if (string.CompareOrdinal(model.SortBy, metadata.PropertyName) == 0)
            {
                htmlAttributes.Add("class", model.SortAscending ? "sortAsc" : "sortDesc");
            }

            MvcHtmlString actionLink = helper.ActionLink(
                metadata.GetDisplayName(), // Link Text
                helper.ViewContext.RouteData.Values["action"].ToString(), // Action
                routeData,  // Route data
                htmlAttributes // HTML attributes to apply to hyperlink
            );

            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("sorting");
            builder.InnerHtml = actionLink.ToHtmlString();

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}