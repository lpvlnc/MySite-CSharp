using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.Application.Services
{
    public class SocialService : ISocialService
    {
        private readonly DataContext _dataContext;

        public SocialService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Social> Get()
        {
            return _dataContext.Socials.ToList();
        }

        public Social GetById(int id)
        {
            var social = _dataContext.Socials.Where(x => x.Id == id).SingleOrDefault();
            return social ?? throw new CustomException($"No data of type {typeof(Social)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Social model)
        {
            model.Id = 0;
            _dataContext.Socials.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Social model)
        {
            var social = _dataContext.Socials.Find(model.Id);

            if (social == null)
                throw new CustomException($"There are no data of type {typeof(Social)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(social).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var social = GetById(id);

            if (social == null)
                throw new CustomException($"There are no data of type {typeof(Social)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Socials.Remove(social);
            _dataContext.SaveChanges();
        }
    }
}
