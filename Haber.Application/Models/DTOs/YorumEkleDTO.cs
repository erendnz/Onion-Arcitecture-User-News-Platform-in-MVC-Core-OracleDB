using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Models.DTOs
{
    public class YorumEkleDTO
    {
        public int HaberID { get; set; }
        public int UserID { get; set; }
        public string Mesaj { get; set; }
    }
}
