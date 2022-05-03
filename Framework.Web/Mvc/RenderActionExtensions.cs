using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Framework.Web.Mvc
{
    /// <summary>
    ///     Contains Extension methods for HtmlHelper that implement wrappers for RenderAction method
    /// </summary>
    public static class RenderActionExtensions
    {
        /// <summary>
        ///     Extension method for HtmlHelper.
        ///     Renders an action on a controller given a lambda expression representing a controller action method.
        /// </summary>
        /// <typeparam name="TController"></typeparam>
        /// <param name="helper"></param>
        /// <param name="action"></param>
        public static void RenderAction<TController>(this HtmlHelper helper, Expression<Action<TController>> action)
            where TController : Controller
        {
            helper.RenderAction(action, null);
        }

        /// <summary>
        ///     Extension method for HtmlHelper.
        ///     Renders an action on a controller given a lambda expression representing a controller action method
        ///     and a dictionary of route values.
        /// </summary>
        /// <typeparam name="TController"></typeparam>
        /// <param name="helper"></param>
        /// <param name="action"></param>
        /// <param name="values"></param>
        public static void RenderAction<TController>(this HtmlHelper helper, Expression<Action<TController>> action,
                                                     RouteValueDictionary values)
            where TController : Controller
        {
            // resolve if dictionary is null
            values = values ?? new RouteValueDictionary();

            // get the controller name and action name
            var type = typeof(TController);
            var controllerName = type.GetControllerName();
            var actionName = action.GetActionName();

            // add the area to the route value dictionary
            values.ProcessArea(type);

            // Render the action 
            helper.RenderAction(actionName, controllerName, values);
        }
    }
}