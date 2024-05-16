using Haber.Domain.Entities;
using Haber.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Models.VMs
{
    public class HaberVM
    {
        public int HaberID { get; set; }
        public string Baslik { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }

        public DateTime EklemeTarih { get; set; }
       
        public string  KategoriAdi { get; set; }

       
    }
}
