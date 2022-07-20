using Portfolio.Model;

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
