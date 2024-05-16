using AutoMapper;
using Haber.Application.Models.DTOs;
using Haber.Application.Models.VMs;
using Haber.Domain.Entities;
using Haber.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.HaberService
{
    public class HaberService : IHaberService
    {
        private readonly IHaberRepository _haberRepository;
        private readonly IMapper _mapper;
        public HaberService(IHaberRepository haberRepository, IMapper mapper)
        {
            _haberRepository = haberRepository;
            this._mapper = mapper;
        }

        public async Task<HaberDetayVM> HaberDetayAsync(int id)
        {
            //var haber =await _haberRepository.BulAsync(id);

            var haber = await _haberRepository.TumunuFiltreleAsync(x => x, x => x.HaberID == id, null, x => x.Include(x => x.Kategori).Include(x=>x.Yorumlar).ThenInclude(x=>x.User));
            HaberDetayVM haberDetay = new HaberDetayVM();

          
           
            _mapper.Map(haber.SingleOrDefault(), haberDetay);

            //List<YorumVM> yorumlar = new List<YorumVM>();
            //_mapper.Map(haberDetay.Yorumlar, yorumlar);
            //haberDetay.Yorumlar= yorumlar;


            return haberDetay;
        }

        public async Task HaberEkleAsync(HaberEkleDTO haber)
        { Haber.Domain.Entities.Haber eklenecekHaber = new Domain.Entities.Haber();
            
            _mapper.Map(haber, eklenecekHaber);
            await _haberRepository.EkleAsync(eklenecekHaber);
        }

        public async Task HaberiPasifHaleGetir(int id)
        {
             await _haberRepository.SilAsync(id);
        }
       
        public async Task<IEnumerable<HaberVM>> TumAktifHaberAsync()
        {
            //var haberler= _haberRepository.BulAsync(x => x.KayitDurumu == Domain.Enums.KayitDurumu.Aktif);

            var haberler = await _haberRepository.TumunuFiltreleAsync(x => x, 
               x => x.KayitDurumu == Domain.Enums.KayitDurumu.Aktif,
               x => x.OrderByDescending(x => x.EklemeTarih), 
               x => x.Include(x => x.Kategori));

            List<HaberVM> haberlerVM = new List<HaberVM>();
            _mapper.Map(haberler, haberlerVM);

            return haberlerVM;

        }

        public async Task<IEnumerable<AdminHaberVM>> TumHaberlerAsync()
        {
            var haberler = await _haberRepository.TumunuGetir().OrderByDescending(x => x.EklemeTarih).Include(x => x.Kategori).ToListAsync();

            List<AdminHaberVM> haberlerVM = new List<AdminHaberVM>();
            _mapper.Map(haberler, haberlerVM);

            return haberlerVM;
        }
    }
}
