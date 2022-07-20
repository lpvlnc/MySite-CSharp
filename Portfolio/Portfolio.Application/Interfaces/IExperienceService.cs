using Portfolio.Model;

namespace Portfolio.Application.Interfaces
{
    public interface IExperienceService
    {
        public List<Experience> Get();
        public Experience GetById(int id);
        public void Add(Experience model);
        public void Update(Experience model);
        public void Delete(int id);
    }
}
