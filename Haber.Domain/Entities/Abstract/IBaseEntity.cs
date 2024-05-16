using Haber.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Domain.Entities.Abstract
{
    public interface IBaseEntity
    {
        public DateTime EklemeTarih { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilmeTarihi { get; set; }

        public KayitDurumu KayitDurumu { get; set; }
    }
}
