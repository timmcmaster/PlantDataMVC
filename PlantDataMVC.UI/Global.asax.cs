using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using PlantDataMVC.UI.Mappers;

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

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();
        }
    }
}