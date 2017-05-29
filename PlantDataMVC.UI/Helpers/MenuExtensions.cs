using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Reflection;

namespace PlantDataMVC.UI.Helpers
{
    /// <summary>
    /// Contains Extension methods for HtmlHelper that implement column headers for tables.
    /// </summary>
    public static class MenuExtensions
    {
        public static MvcHtmlString ListItemFor<TController>(this HtmlHelper helper, string linkText, Expression<Action<TController>> action)
            where TController : Controller
        {
            // get the controller name and action name
            Type type = typeof(TController);
            string controllerName = type.GetControllerName();
            string actionName = action.GetActionName();

            return ListItem(helper, linkText, actionName, controllerName);
        }

        public static MvcHtmlString BeginListItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            TagBuilder builder = GetListItemBuilder(helper, linkText, actionName, controllerName);
            string htmlString = builder.ToString(TagRenderMode.StartTag) + builder.InnerHtml;

            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString EndListItem(this HtmlHelper helper)
        {
            TagBuilder builder = new TagBuilder("li");

            string htmlString = builder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString ListItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            TagBuilder builder = GetListItemBuilder(helper, linkText, actionName, controllerName);

            string htmlString = builder.ToString();
            return MvcHtmlString.Create(htmlString);
        }

        public static TagBuilder GetListItemBuilder(HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            TagBuilder builder = new TagBuilder("li");
            builder.InnerHtml = helper.ActionLink(linkText, actionName, controllerName).ToHtmlString();

            if (IsCurrentAction(helper, actionName, controllerName))
            {
                // add css info to item
                builder.MergeAttribute("class", "current");
            }

            return builder;
        }

        private static bool IsCurrentAction(HtmlHelper helper, string actionName, string controllerName)
        {
            string currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            string currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}