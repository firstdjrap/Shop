using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorage _storage;

        public StorageController(IStorage storage)
        {
            _storage = storage;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Storage storage)
        {
            storage.CreatedAt = DateTime.Now;

            try
            {
                _storage.Add(storage);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        public ActionResult GetStorages()
        {
            var storages = _storage.GetList();

            return Json(storages);
        }

        public ActionResult Edit(int id)
        {
            var storage = _storage.Get(id);

            return View(storage);
        }

        [HttpPost]
        public ActionResult Edit([FromBody] Storage storage)
        {
            try
            {
                _storage.Edit(storage);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Delete([FromBody] Storage storage)
        {
            try
            {
                _storage.Delete(storage.Id);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    }
}