using Haber.Domain.Entities;
using Haber.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.Repositories.Concrete
{
    public class FavoriRepository : BaseRepository<Favori>,IFavoriRepository
    {
        public FavoriRepository(HaberContext context) : base(context)
        {
        }
    }
}
