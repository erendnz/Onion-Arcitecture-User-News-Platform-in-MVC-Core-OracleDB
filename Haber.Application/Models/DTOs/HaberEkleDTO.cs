using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Models.DTOs
{
    public class HaberEkleDTO
    {
        public string Baslik { get; set; }
        public string Detay { get; set; }

        public int KategoriID { get; set; }
        public int HaberEkleyenID { get; set; }
        public string ResimYolu { get; set; }
    }
}
