using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace PlantDataMVC.UICore.Controllers
{
    public class HeaderController : DefaultController
    {
        public IActionResult Logout()
        {
            return SignOut(CookieAuthenticationDefaults.AuthenticationScheme, "oidc");
        }
    }
}