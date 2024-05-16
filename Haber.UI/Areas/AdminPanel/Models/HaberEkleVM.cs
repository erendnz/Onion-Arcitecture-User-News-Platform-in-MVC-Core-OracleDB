using Microsoft.AspNetCore.Mvc.Rendering;

namespace Haber.UI.Areas.AdminPanel.Models
{
    public class HaberEkleVM
    {
        public string Baslik { get; set; }
        public string Detay { get; set; }

        public int KategoriID { get; set; }
        public int HaberEkleyenID { get; set; }

        public IFormFile  ResimDosyasi { get; set; }
        public SelectList Kategoriler { get; set; }

    }
}
