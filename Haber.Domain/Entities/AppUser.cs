using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Domain.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }


        public ICollection<Yorum> Yorumlar { get; set; }
        public ICollection<Favori> Favoriler { get; set; }
        public ICollection<Haber> Haberler { get; set; }
    }
}
