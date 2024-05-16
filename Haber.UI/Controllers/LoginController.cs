using Haber.Application.Models.DTOs;
using Haber.Application.Services.AppUserService;
using Microsoft.AspNetCore.Mvc;

namespace Haber.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppUserService _service;

        public LoginController(IAppUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result= await _service.LoginAsync(login);

            if (result.IsUser)
            {
                if (result.IsAdmin)
                    return RedirectToAction("Index", "Home", new { Area = "AdminPanel" });
                else
                    return RedirectToAction("Index", "Home", new { Area = "UyePanel" });
            }
            return View();
            
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UyeKayitDTO yeniUye)
        {
            bool result=false;
            if (yeniUye.Password == yeniUye.ConfirmPassword)
            {
                result = await _service.RegisterAsync(yeniUye);
                //Kayit oldugunda ise...
                return RedirectToAction("Login", "Login");

            }

            ModelState.AddModelError("Sifre", "Sifre ve Sifre Tekrar aynı olmalı...");
            return View(yeniUye);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
