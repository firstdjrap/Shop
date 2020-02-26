using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Models;
using Shop.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Shop.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IMapper _mapper;
        private readonly IEmployee _employee;

        public EmployeeController(IMapper mapper, IEmployee employee)
        {
            _mapper = mapper;
            _employee = employee;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([FromBody] AccountInputViewModel accountViewModel)
        {
            Employee employee = new Employee
            {
                PhoneNumber = accountViewModel.PhoneNumber,
                Password = accountViewModel.Password,
            };
            var account = _employee.VerifyEmployee(employee);
            AccountOutputViewModel accountOutputViewModel;
            if (account == null)
            {
                accountOutputViewModel = new AccountOutputViewModel { Message = "Ошибка! Введены неверные данные аккаунта!" };
                return Json(accountOutputViewModel);
            }

            accountOutputViewModel = new AccountOutputViewModel { FirstName = account.FirstName, Message = "Success" };
            return Json(accountOutputViewModel);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp([FromBody] AccountInputViewModel accountViewModel)
        {
            Employee employee = new Employee
            {
                FirstName = accountViewModel.FirstName,
                LastName = accountViewModel.LastName,
                PhoneNumber = accountViewModel.PhoneNumber,
                Password = accountViewModel.Password,
                CreatedAt = DateTime.Now
            };
            var account = _employee.CreateEmployee(employee);
            if (!account)
                return Json("Ошибка! Пользователь с такими данными уже существует!");

            return Json("Success");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            var employee = _employee.GetList();

            var employeeOutput = _mapper.Map<IEnumerable<EmployeeOutputViewModel>>(employee);
            
            return Json(employeeOutput);
        }
    }
}