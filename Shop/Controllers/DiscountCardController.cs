using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class DiscountCardController : Controller
    {
        private readonly IDiscountCard _discountCard;

        public DiscountCardController(IDiscountCard discountCard)
        {
            _discountCard = discountCard;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromBody] DiscountCard discountCard)
        {
            discountCard.CreatedAt = DateTime.Now;

            try
            {
                _discountCard.Add(discountCard);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        public ActionResult GetDiscountCards()
        {
            var discountCards = _discountCard.GetList();

            return Json(discountCards);
        }

        public ActionResult Edit(int id)
        {
            var discountCard = _discountCard.Get(id);

            return View(discountCard);
        }

        [HttpPost]
        public ActionResult Edit([FromBody] DiscountCard discountCard)
        {
            try
            {
                _discountCard.Edit(discountCard);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Delete([FromBody] DiscountCard discountCard)
        {
            try
            {
                _discountCard.Delete(discountCard.Id);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    }
}