using System.Web.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class DefaultController : Controller
    {
        protected ActionResult DefaultFormFailureResult()
        {
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}