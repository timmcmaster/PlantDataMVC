using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.Web.Controllers
{
    public class DefaultController : Controller
    {
        protected ActionResult DefaultFormFailureResult()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
