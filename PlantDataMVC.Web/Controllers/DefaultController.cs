using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Controllers
{
    public class DefaultController : Controller
    {
        protected ActionResult DefaultFormFailureResult()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
