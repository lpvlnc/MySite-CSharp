using AutoMapper;
using Portfolio.Application.Interfaces;
using Portfolio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class HomeService : IHomeService
    {

        private readonly IMeService _meService;
        private readonly IMapper _mapper;

        public HomeService(IMeService meService, IMapper mapper)
        {
            _meService = meService;
            _mapper = mapper;
        }

        public MeDto GetMe()
        {
            var me = _meService.Get();
            return _mapper.Map<MeDto>(me);
        }

        public MeAboutDto GetAbout()
        {
            var me = _meService.Get();
            return _mapper.Map<MeAboutDto>(me);
        }
    }
}
