using Portfolio.Model;

namespace Portfolio.Application.Interfaces
{
    public interface ITagService
    {
        public List<Tag> Get();
        public Tag GetById(int id);
        public void Add(Tag model);
        public void Update(Tag model);
        public void Delete(int id);
    }
}
