using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using Shop.Services.Interfaces;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository productRepository;
        IOrder order;

        public HomeController(IProductRepository productRepository, IOrder order)
        {
            this.productRepository = productRepository;
            this.order = order;
        }

        public ActionResult Index()
        {
            var product = productRepository.GetList();
            return View(product);
        }

        public ActionResult Buy(int id)
        {
            Product product = productRepository.Get(id);
            order.MakeOrder(product);
            return View();
        }
    }
}