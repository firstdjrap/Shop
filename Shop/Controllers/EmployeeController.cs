using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Models;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([FromBody] EmployeeInputViewModel employeeViewModel)
        {
            Employee employee = new Employee
            {
                PhoneNumber = employeeViewModel.PhoneNumber,
                Password = employeeViewModel.Password,
            };
            var account = this.employee.VerifyEmployee(employee);
            EmployeeOutputViewModel employeeOutputViewModel;
            if (account == null)
            {
                employeeOutputViewModel = new EmployeeOutputViewModel { Message = "Ошибка! Введены неверные данные аккаунта!" };
                return Json(employeeOutputViewModel);
            }

            employeeOutputViewModel = new EmployeeOutputViewModel { FirstName = account.FirstName, Message = "Success" };
            return Json(employeeOutputViewModel);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp([FromBody] EmployeeInputViewModel employeeViewModel)
        {
            Employee employee = new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                PhoneNumber = employeeViewModel.PhoneNumber,
                Password = employeeViewModel.Password,
                CreatedAt = DateTime.Now
            };
            var account = this.employee.CreateEmployee(employee);
            if (!account)
                return Json("Ошибка! Пользователь с такими данными уже существует!");

            return Json("Success");
        }
    }
}