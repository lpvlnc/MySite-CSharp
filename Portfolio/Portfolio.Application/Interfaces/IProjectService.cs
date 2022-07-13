using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface IProjectService
    {
        public List<Project> Get();
        public Project GetById(int id);
        public void Add(Project model);
        public void Update(Project model);
        public void Delete(int id);
    }
}
