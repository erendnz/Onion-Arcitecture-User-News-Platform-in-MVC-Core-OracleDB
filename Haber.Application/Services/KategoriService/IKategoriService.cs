using Haber.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.KategoriService
{
    public interface IKategoriService
    {
        Task<IEnumerable<KategoriDTO>> TumAktifKategorilerAsync();
    }
}
