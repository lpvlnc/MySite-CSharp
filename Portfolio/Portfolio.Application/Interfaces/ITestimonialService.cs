using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.Interfaces
{
    public interface ITestimonialService
    {
        public List<Testimonial> Get();
        public Testimonial GetById(int id);
        public void Add(Testimonial model);
        public void Update(Testimonial model);
        public void Delete(int id);
    }
}
