using System;
using Framework.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Framework.Web.Mvc
{
    /// <summary>
    ///     Contains extension methods for RouteValueDictionary class
    /// </summary>
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        ///     Extension method for copying query string parameters to a RouteValueDictionary.
        /// </summary>
        public static RouteValueDictionary AddQueryStringParameters(this RouteValueDictionary routeValues, HttpRequest fromRequest)
        {
            if ((fromRequest != null) && (fromRequest.Query != null))
            {
                var query = fromRequest.Query;

                foreach (var key in query.Keys)
                {
                    if (!routeValues.ContainsKey(key))
                    {
                        routeValues.Add(key, query[key]);
                    }
                }
            }
            return routeValues;
        }

        /// <summary>
        ///     Extension method for excluding specific query string parameters from a RouteValueDictionary.
        /// </summary>
        public static RouteValueDictionary ExceptFor(this RouteValueDictionary routeValues,
                                                     params string[] keysToRemove)
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
        ///     Extension method for adding the area name for a given controller to the RouteValueDictionary.
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