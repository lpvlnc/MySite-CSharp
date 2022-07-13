using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ISocialService
    {
        public List<Social> Get();
        public Social GetById(int id);
        public void Add(Social model);
        public void Update(Social model);
        public void Delete(int id);
    }
}
