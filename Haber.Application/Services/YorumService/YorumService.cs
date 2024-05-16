using AutoMapper;
using Haber.Application.Models.DTOs;
using Haber.Domain.Entities;
using Haber.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Application.Services.YorumService
{
    public class YorumService : IYorumService
    {
        private readonly IYorumRepository _yorumRepository;
        private readonly IMapper _mapper;

        public YorumService(IYorumRepository yorumRepository, IMapper mapper)
        {
            _yorumRepository = yorumRepository;
            _mapper = mapper;
        }

        public async Task YorumEkleAsync(YorumEkleDTO yorum)
        {
            var eklenecekYorum = new Yorum();
            _mapper.Map(yorum, eklenecekYorum);
            await _yorumRepository.EkleAsync(eklenecekYorum);
        }
    }
}
