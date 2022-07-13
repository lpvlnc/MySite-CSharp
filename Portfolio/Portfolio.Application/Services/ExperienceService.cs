using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly DataContext _dataContext;

        public ExperienceService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Experience> Get()
        {
            return _dataContext.Experiences.ToList();
        }

        public Experience GetById(int id)
        {
            var experience = _dataContext.Experiences.Where(x => x.Id == id).SingleOrDefault();
            return experience ?? throw new CustomException($"No data of type {typeof(Experience)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Experience model)
        {
            model.Id = 0;
            _dataContext.Experiences.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Experience model)
        {
            var experience = _dataContext.Experiences.Find(model.Id);

            if (experience == null)
                throw new CustomException($"There are no data of type {typeof(Experience)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(experience).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var experience = GetById(id);

            if (experience == null)
                throw new CustomException($"There are no data of type {typeof(Experience)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Experiences.Remove(experience);
            _dataContext.SaveChanges();
        }
    }
}