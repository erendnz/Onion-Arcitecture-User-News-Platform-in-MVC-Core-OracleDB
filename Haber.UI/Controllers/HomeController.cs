using Haber.Application.Services.HaberService;
using Haber.Domain.Entities;
using Haber.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Haber.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHaberService _haberService;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(IHaberService haberService, 
              SignInManager<AppUser> signInManager)
        {
            _haberService = haberService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var haberler=await _haberService.TumAktifHaberAsync();
           return View(haberler);
        }

        public async Task<IActionResult> HaberDetay(int id)
        {
            var haberDetay = await _haberService.HaberDetayAsync(id);
            haberDetay.IsSignedUser = _signInManager.IsSignedIn(User);
            return View(haberDetay);
        }
    }
}