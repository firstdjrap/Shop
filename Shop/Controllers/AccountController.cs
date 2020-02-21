using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}