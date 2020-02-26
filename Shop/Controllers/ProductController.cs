using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            var branchOffices = _product.GetList();

            return Json(branchOffices);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Product product)
        {
            product.CreatedAt = DateTime.Now;

            try
            {
                _product.Add(product);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        public ActionResult Edit(int id)
        {
            var product = _product.Get(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit([FromBody] Product product)
        {
            try
            {
                _product.Edit(product);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Delete([FromBody] Product product)
        {
            try
            {
                _product.Delete(product.Id);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    }
}