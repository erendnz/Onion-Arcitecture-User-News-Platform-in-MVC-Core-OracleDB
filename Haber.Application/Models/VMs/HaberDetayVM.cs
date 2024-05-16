using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Models.VMs
{
    public class HaberDetayVM
    {
        public int HaberID { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        public DateTime EklemeTarih { get; set; }
        public string KategoriAdi { get; set; }

        public IEnumerable<YorumVM> Yorumlar {get;set;}

        public bool IsSignedUser { get; set; } = false;

    }
}
