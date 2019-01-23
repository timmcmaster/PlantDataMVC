using Framework.Web.Mvc;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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
            var controllerName = type.GetControllerName();
            var actionName = action.GetActionName();

            return ListItem(helper, linkText, actionName, controllerName);
        }

        public static MvcHtmlString BeginListItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            TagBuilder builder = GetListItemBuilder(helper, linkText, actionName, controllerName);
            var htmlString = builder.ToString(TagRenderMode.StartTag) + builder.InnerHtml;

            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString EndListItem(this HtmlHelper helper)
        {
            var builder = new TagBuilder("li");

            var htmlString = builder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(htmlString);
        }

        public static MvcHtmlString ListItem(this HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            TagBuilder builder = GetListItemBuilder(helper, linkText, actionName, controllerName);

            var htmlString = builder.ToString();
            return MvcHtmlString.Create(htmlString);
        }

        public static TagBuilder GetListItemBuilder(HtmlHelper helper, string linkText, string actionName, string controllerName)
        {
            var builder = new TagBuilder("li")
            {
                InnerHtml = helper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
            };

            if (IsCurrentAction(helper, actionName, controllerName))
            {
                // add css info to item
                builder.MergeAttribute("class", "current");
            }

            return builder;
        }

        private static bool IsCurrentAction(HtmlHelper helper, string actionName, string controllerName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            return currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                   currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}