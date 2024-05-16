using Haber.Domain.Entities.Abstract;
using Haber.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Domain.Entities
{
    public class Haber:IBaseEntity
    {
        public int HaberID { get; set; }
        public string Baslik { get; set; }
        public string Detay { get; set; }
        public string? ResimYolu { get; set; }
        public int GoruntulenmeSayisi { get; set; }


        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }

        //HaberEkleyen
        [ForeignKey("User")]
        public int HaberEkleyenID { get; set; }

        //UserID, KategoriID
        public int KategoriID { get; set; }
        
        public Kategori Kategori { get; set; }

        public AppUser User { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        public ICollection<Favori> Favoriler { get; set; }
    }
}
