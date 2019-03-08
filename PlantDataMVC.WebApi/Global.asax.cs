using System;
using System.Web;
using System.Web.Routing;

namespace PlantDataMVC.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
        }

        /* Added for route debugging */
        public override void Init()
        {
            base.Init();
            AcquireRequestState += ShowRouteValues;
        }

        protected void ShowRouteValues(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return;
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
        }
    }
}
