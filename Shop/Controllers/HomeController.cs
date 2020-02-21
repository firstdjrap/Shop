using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}