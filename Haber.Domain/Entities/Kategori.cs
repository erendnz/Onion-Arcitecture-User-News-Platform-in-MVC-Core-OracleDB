using Haber.Domain.Entities.Abstract;
using Haber.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Domain.Entities
{
    public class Kategori:IBaseEntity
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }
        public KayitDurumu KayitDurumu { get; set; }

        public ICollection<Haber> Haberler { get; set; }
    }
}
