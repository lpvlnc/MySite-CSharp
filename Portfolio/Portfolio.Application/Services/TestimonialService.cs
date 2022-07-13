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
    public class TestimonialService : ITestimonialService
    {
        private readonly DataContext _dataContext;

        public TestimonialService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Testimonial> Get()
        {
            return _dataContext.Testimonials.ToList();
        }

        public Testimonial GetById(int id)
        {
            var social = _dataContext.Testimonials.Where(x => x.Id == id).SingleOrDefault();
            return social ?? throw new CustomException($"No data of type {typeof(Testimonial)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Testimonial model)
        {
            model.Id = 0;
            _dataContext.Testimonials.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Testimonial model)
        {
            var social = _dataContext.Testimonials.Find(model.Id);

            if (social == null)
                throw new CustomException($"There are no data of type {typeof(Testimonial)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(social).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var social = GetById(id);

            if (social == null)
                throw new CustomException($"There are no data of type {typeof(Testimonial)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Testimonials.Remove(social);
            _dataContext.SaveChanges();
        }
    }
}
