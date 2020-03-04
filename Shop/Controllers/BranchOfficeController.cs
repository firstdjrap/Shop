using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class BranchOfficeController : Controller
    {
        private readonly IBranchOffice _branchOffice;

        public BranchOfficeController(IBranchOffice branchOffice)
        {
            _branchOffice = branchOffice;
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
        public ActionResult Create([FromBody] BranchOffice branchOffice)
        {
            branchOffice.CreatedAt = DateTime.Now;

            try
            {
                _branchOffice.Add(branchOffice);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    
        public ActionResult GetBranchOffices()
        {
            var branchOffices = _branchOffice.GetList();

            return Json(branchOffices);
        }

        public ActionResult Edit(int id)
        {
            var branchOffice =  _branchOffice.GetById(id);

            return View(branchOffice);
        }

        [HttpPost]
        public ActionResult Edit([FromBody] BranchOffice branchOffice)
        {
            try
            {
                _branchOffice.Edit(branchOffice);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }

        [HttpPost]
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                _branchOffice.Delete(id);
            }
            catch
            {
                return Json("Непредвиденная ошибка!");
            }

            return Json("Success");
        }
    }
}