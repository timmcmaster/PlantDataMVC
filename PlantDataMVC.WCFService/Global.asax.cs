using System;
using System.Web;

namespace PlantDataMVC.WCFService
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AutofacConfig.ConfigureContainer();
        }
    }
}