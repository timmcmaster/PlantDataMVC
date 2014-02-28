using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Reflection;

namespace PlantDataMvc3.UI.Helpers
{
    /// <summary>
    /// Contains Extension methods for HtmlHelper that implement wrappers for RenderAction method
    /// </summary>
    public static class PagingExtensions
    {
        public static MvcHtmlString PagingLinksFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expr) //where TModel : IPageable
        {
            IPageable model = helper.ViewData.Model as IPageable;

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expr, helper.ViewData);

            MvcHtmlString prevLink = new MvcHtmlString("");
            MvcHtmlString separator = new MvcHtmlString("");
            MvcHtmlString nextLink = new MvcHtmlString("");

            if (model != null)
            {
                if (model.HasPreviousPage)
                {
                    RouteValueDictionary routeDataPrev = new RouteValueDictionary { { "page", (model.PageIndex - 1) }, { "pageSize", model.PageSize } };
                    routeDataPrev.AddQueryStringParameters();

                    prevLink = helper.ActionLink("< Previous Page", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataPrev);
                }

                if ((model.HasPreviousPage) && (model.HasNextPage))
                {
                    TagBuilder builder = new TagBuilder("text");
                    builder.InnerHtml = "&nbsp;|&nbsp;";

                    separator = MvcHtmlString.Create(builder.ToString());
                }

                if (model.HasNextPage)
                {
                    RouteValueDictionary routeDataNext = new RouteValueDictionary { { "page", (model.PageIndex + 1) }, { "pageSize", model.PageSize } };
                    routeDataNext.AddQueryStringParameters();

                    nextLink = helper.ActionLink("Next Page >", helper.ViewContext.RouteData.Values["action"].ToString(), routeDataNext);
                }
            }

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("pagination");
            divBuilder.InnerHtml = prevLink.ToHtmlString() + separator.ToHtmlString() + nextLink.ToHtmlString();

            return MvcHtmlString.Create(divBuilder.ToString());
        }
    }
}