using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Models.VMs
{
    public class YorumVM
    {
        public int YorumID { get; set; }
        public string UserName { get; set; }
        public string Mesaj { get; set; }

        public DateTime EklemeTarih { get; set; }
    }
}
