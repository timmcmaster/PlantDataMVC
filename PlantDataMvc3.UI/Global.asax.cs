using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PlantDataMvc3.UI.Mappers;
using StackExchange.Profiling;
//using StackExchange.Profiling.MVCHelpers;

namespace PlantDataMvc3.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();
        }

        protected void Application_BeginRequest()
        {
            MiniProfiler profiler = null;

            // might want to decide here (or maybe inside the action) whether you want
            // to profile this request - for example, using an "IsSystemAdmin" flag against
            // the user, or similar; this could also all be done in action filters, but this
            // is simple and practical; just return null for most users. For our test, we'll
            // profile only for local requests (seems reasonable)
            if (Request.IsLocal)
            {
                profiler = MiniProfiler.Start();
            }

            using (profiler.Step("Application_BeginRequest"))
            {
                // you can start profiling your code immediately
            }
        }

        /// <summary>
        /// The application end request.
        /// </summary>
        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

    }
}