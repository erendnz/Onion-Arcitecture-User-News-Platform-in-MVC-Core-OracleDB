using AutoMapper;
using Haber.Application.Models.DTOs;
using Haber.Application.Services.AppUserService;
using Haber.Application.Services.HaberService;
using Haber.Application.Services.KategoriService;
using Haber.UI.Areas.AdminPanel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Haber.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class HaberController : Controller
    {
        private readonly IHaberService _haberService;
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _userService;

        public HaberController(IHaberService haberService, IKategoriService kategoriService, IMapper mapper, IAppUserService userService)
        {
            _haberService = haberService;
            _kategoriService = kategoriService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            //Tum haberleri goster...
            var haberler = await _haberService.TumHaberlerAsync();

            return View(haberler);

            //return View(await _kategoriService.TumAktifKategorilerAsync());

        }
        public async Task<IActionResult> HaberEkle()
        {
            HaberEkleVM haberVM = new HaberEkleVM();
            haberVM.Kategoriler = new SelectList(await _kategoriService.TumAktifKategorilerAsync(), "KategoriID", "KategoriAdi"); 

          return View(haberVM);
        }

        [HttpPost]
        public async Task<IActionResult> HaberEkle(HaberEkleVM haber)
        {
            HaberEkleDTO haberDTO = new HaberEkleDTO();

            haberDTO.Baslik = haber.Baslik;
            haberDTO.Detay = haber.Detay;
            haberDTO.KategoriID = haber.KategoriID;

            haberDTO.ResimYolu = haber.ResimDosyasi.FileName;

            FileStream fs = new FileStream("wwwroot/HaberResimleri/" + haber.ResimDosyasi.FileName, FileMode.Create);
            await haber.ResimDosyasi.CopyToAsync(fs);
            fs.Close();

            haberDTO.HaberEkleyenID = _userService.GetUserID(User);
          
            await  _haberService.HaberEkleAsync(haberDTO);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> HaberSil(int ID)
        {
            //await Console.Out.WriteLineAsync(ID+"...........");
            await _haberService.HaberiPasifHaleGetir(ID); 
            return RedirectToAction("Index");
        }
    }
}
