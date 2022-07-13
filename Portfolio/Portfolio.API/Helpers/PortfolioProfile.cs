using AutoMapper;
using Portfolio.DTO;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.API
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Me, MeDto>().ReverseMap();
            CreateMap<Me, MeAboutDto>().ReverseMap();
        }
    }
}
