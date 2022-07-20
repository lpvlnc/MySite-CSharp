using Portfolio.Model;

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
