using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Web;

namespace PlantDataMVC.WCFService
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            IContainer container = AutofacConfig.ConfigureContainer();
            AutofacHostFactory.Container = container;
        }
    }
}