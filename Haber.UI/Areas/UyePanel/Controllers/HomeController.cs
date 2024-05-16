using Haber.Application.Models.DTOs;
using Haber.Application.Services.AppUserService;
using Haber.Application.Services.YorumService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Haber.UI.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Admin,Uye")]
    public class HomeController : Controller
    {
        private readonly IYorumService _yorumService;
        private readonly IAppUserService _appUserService;

        public HomeController(IYorumService yorumService, IAppUserService appUserService)
        {
            _yorumService = yorumService;
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YorumEkle(YorumEkleDTO yorum)
        {
            yorum.UserID = _appUserService.GetUserID(User);
            //await Console.Out.WriteLineAsync(".........."+ yorum.HaberID + " " + yorum.UserID);
            
            await _yorumService.YorumEkleAsync(yorum);
            return RedirectToAction("HaberDetay","Home",new { Area="", id=yorum.HaberID });
        }
    }
}
