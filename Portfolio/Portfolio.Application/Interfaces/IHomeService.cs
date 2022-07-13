using Portfolio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IHomeService
    {
        public MeDto GetMe();
        public MeAboutDto GetAbout();
    }
}
