using Autofac;
using Autofac.Integration.WebApi;
using PlantDataMVC.WebApi.Mappers;
using System.Web.Http;

namespace PlantDataMVC.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;

            // Set the dependency resolver to be Autofac.
            IContainer container = AutofacConfig.ConfigureContainer();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();

        }
    }
}
