using AutoMapper;
using Haber.Application.Models.DTOs;
using Haber.Application.Models.VMs;
using Haber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.AutoMapper
{
    public class HaberMapper:Profile
    {
        public HaberMapper()
        {
            CreateMap<Kategori, KategoriDTO>().ReverseMap();

            CreateMap<HaberEkleDTO, Haber.Domain.Entities.Haber>().ReverseMap();

            CreateMap<HaberVM, Haber.Domain.Entities.Haber>()
                .ReverseMap().ForMember(x => x.KategoriAdi, x => x.MapFrom(x => x.Kategori.KategoriAdi));

            CreateMap<HaberDetayVM, Haber.Domain.Entities.Haber>().ReverseMap()
                .ForMember(x => x.KategoriAdi, x => x.MapFrom(x => x.Kategori.KategoriAdi))
                .ForMember(x => x.Yorumlar, x => x.MapFrom(x => x.Yorumlar));
               

            CreateMap<Yorum, YorumEkleDTO>().ReverseMap();

            CreateMap<YorumVM,Yorum>().ReverseMap()
                .ForMember(x=>x.UserName, x=>x.MapFrom(x=>x.User.UserName));

            CreateMap<Haber.Domain.Entities.Haber,AdminHaberVM>().ReverseMap();

        }
    }
}
