using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Models;
using Shop.Services.Interfaces;
using System;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IClient _client;

        public AccountController(IClient client)
        {
            _client = client;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([FromBody] AccountInputViewModel accountViewModel)
        {
            Client client = new Client
            {
                PhoneNumber = accountViewModel.PhoneNumber,
                Password = accountViewModel.Password
            };
            var account = _client.VerifyEmployee(client);
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
            Client client = new Client
            {
                FirstName = accountViewModel.FirstName,
                LastName = accountViewModel.LastName,
                PhoneNumber = accountViewModel.PhoneNumber,
                Password = accountViewModel.Password,
                Address = accountViewModel.Address,
                CreatedAt = DateTime.Now
            };
            var account = _client.CreateEmployee(client);
            if (!account)
                return Json("Ошибка! Пользователь с такими данными уже существует!");

            return Json("Success");
        }
    }
}