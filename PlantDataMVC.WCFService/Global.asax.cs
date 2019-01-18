using Autofac;
using Autofac.Integration.Wcf;
using PlantDataMVC.WCFService.Mappers;
using System;
using System.Web;

namespace PlantDataMVC.WCFService
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            IContainer container = AutofacConfig.ConfigureContainer();
            AutofacHostFactory.Container = container;

            // Configure mappings for all objects
            AutoMapperBootstrapper.Initialize();
        }
    }
}