using Haber.Domain.Entities;
using Haber.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.Repositories.Concrete
{
    public class KategoriRepository : BaseRepository<Kategori>,IKategoriRepository
    {
        public KategoriRepository(HaberContext context) : base(context)
        {
        }
    }
}
