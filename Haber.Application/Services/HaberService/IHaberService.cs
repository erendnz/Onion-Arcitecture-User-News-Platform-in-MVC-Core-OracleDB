using Haber.Application.Models.DTOs;
using Haber.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.HaberService
{
    public interface IHaberService
    {
        Task HaberEkleAsync(HaberEkleDTO haber);
        Task<IEnumerable<HaberVM>> TumAktifHaberAsync();
        Task<IEnumerable<AdminHaberVM>> TumHaberlerAsync();

        Task<HaberDetayVM> HaberDetayAsync(int id);

        Task HaberiPasifHaleGetir(int id);

    }   

}
