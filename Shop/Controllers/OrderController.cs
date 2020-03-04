using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Services.Interfaces;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly IProduct _product;

        public OrderController(IOrder order, IProduct product)
        {
            _order = order;
            _product = product;
        }

        public ActionResult Create(int id)
        {
            var product = _product.GetById(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrderProduct orderProduct)
        {
            try
            {
                _order.Add(orderProduct);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    }
}