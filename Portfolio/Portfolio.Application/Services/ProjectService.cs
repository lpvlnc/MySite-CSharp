using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _dataContext;

        public ProjectService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Project> Get()
        {
            return _dataContext.Projects.ToList();
        }

        public Project GetById(int id)
        {
            var project = _dataContext.Projects.Where(x => x.Id == id).SingleOrDefault();
            return project ?? throw new CustomException($"No data of type {typeof(Project)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Project model)
        {
            model.Id = 0;
            _dataContext.Projects.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Project model)
        {
            var project = _dataContext.Projects.Find(model.Id);

            if (project == null)
                throw new CustomException($"There are no data of type {typeof(Project)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(project).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var project = GetById(id);

            if (project == null)
                throw new CustomException($"There are no data of type {typeof(Project)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Projects.Remove(project);
            _dataContext.SaveChanges();
        }
    }
}
