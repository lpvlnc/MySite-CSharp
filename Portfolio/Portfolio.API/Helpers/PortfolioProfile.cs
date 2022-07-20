using AutoMapper;
using Portfolio.DTO;
using Portfolio.Model;

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
