using Portfolio.DTO;

namespace Portfolio.Application.Interfaces
{
    public interface IHomeService
    {
        public MeDto GetMe();
        public MeAboutDto GetAbout();
    }
}
