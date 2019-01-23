using System;
using System.Web;
using System.Web.Routing;

namespace Framework.Web.Mvc
{
    /// <summary>
    /// Contains extension methods for RouteValueDictionary class
    /// </summary>
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Extension method for copying query string parameters to a RouteValueDictionary.
        /// </summary>
        public static RouteValueDictionary AddQueryStringParameters(this RouteValueDictionary routeValues)
        {
            var queryString = HttpContext.Current.Request.QueryString;

            foreach (var key in queryString.AllKeys)
            {
                if (!routeValues.ContainsKey(key))
                {
                    routeValues.Add(key, queryString.GetValues(key)[0]);
                }
            }

            return routeValues;
        }

        /// <summary>
        /// Extension method for excluding specific query string parameters from a RouteValueDictionary.
        /// </summary>
        public static RouteValueDictionary ExceptFor(this RouteValueDictionary routeValues, params string[] keysToRemove)
        {
            foreach (var key in keysToRemove)
            {
                if (routeValues.ContainsKey(key))
                {
                    routeValues.Remove(key);
                }
            }

            return routeValues;
        }

        /// <summary>
        /// Extension method for adding the area name for a given controller to the RouteValueDictionary.
        /// </summary>
        public static void ProcessArea(this RouteValueDictionary routeValues, Type targetControllerType)
        {
            var areaName = targetControllerType.GetAreaName() ?? string.Empty;

            if (routeValues.ContainsKey("area"))
            {
                routeValues["area"] = areaName;
            }
            else
            {
                routeValues.Add("area", areaName);
            }
        }
    }
}