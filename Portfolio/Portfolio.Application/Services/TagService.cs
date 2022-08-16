using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.Application.Services
{
    public class TagService : ITagService
    {
        private readonly DataContext _dataContext;

        public TagService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Tag> Get()
        {
            return _dataContext.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            var social = _dataContext.Tags.Where(x => x.Id == id).SingleOrDefault();
            return social ?? throw new CustomException($"No data of type {typeof(Tag)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Tag model)
        {
            model.Id = 0;
            _dataContext.Tags.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Tag model)
        {
            var social = _dataContext.Tags.Find(model.Id);

            if (social == null)
                throw new CustomException($"There are no data of type {typeof(Tag)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(social).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = GetById(id);

            if (tag == null)
                throw new CustomException($"There are no data of type {typeof(Tag)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Tags.Remove(tag);
            _dataContext.SaveChanges();
        }
    }
}
