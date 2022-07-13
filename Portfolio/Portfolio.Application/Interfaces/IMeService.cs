using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IMeService
    {
        public Me Get();

        public void Add(Me model);

        public void Update(Me model);

        public void Delete();
    }
}
