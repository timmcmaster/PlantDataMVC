using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UI.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Logout()
        {
            // TODO: Check this one. Where was it used?
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}