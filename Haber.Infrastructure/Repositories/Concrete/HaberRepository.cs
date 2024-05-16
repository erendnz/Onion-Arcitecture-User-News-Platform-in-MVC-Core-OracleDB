using Haber.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Infrastructure.Repositories.Concrete
{
    public class HaberRepository : BaseRepository<Haber.Domain.Entities.Haber>,IHaberRepository
    {
        public HaberRepository(HaberContext context) : base(context)
        {
        }
    }
}
