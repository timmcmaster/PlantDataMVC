using Microsoft.AspNetCore.Mvc;

namespace PlantData.Web.Mvc.Controllers
{
    public class DefaultController : Controller
    {
        protected ActionResult DefaultFormFailureResult()
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
