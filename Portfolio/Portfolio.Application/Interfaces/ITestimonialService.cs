using Portfolio.Model;

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
