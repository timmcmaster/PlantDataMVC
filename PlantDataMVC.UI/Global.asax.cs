using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using PlantDataMVC.UI.Mappers;

//using StackExchange.Profiling.MVCHelpers;

namespace PlantDataMVC.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Force break here
            //System.Diagnostics.Debugger.Break();

            var container = AutofacConfig.ConfigureContainer();
            // Set the dependency resolver to be Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();
        }
    }
}