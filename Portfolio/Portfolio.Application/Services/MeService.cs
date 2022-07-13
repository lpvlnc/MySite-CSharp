using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.Application.Services
{
    public class MeService : IMeService
    {

        private readonly DataContext _dataContext;

        public MeService(DataContext context)
        {
            _dataContext = context;
        }

        public Me Get()
        {
            var me = _dataContext.Me.FirstOrDefault();
            return me ?? throw new CustomException("No data found.", string.Empty, 412);
        }

        public void Add(Me model)
        {
            var me = _dataContext.Me.FirstOrDefault();

            if (me != null)
                throw new CustomException($"'Me' data are already defined, you can try to update it.", string.Empty, 412);

            model.Id = 0;
            _dataContext.Me.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Me model)
        {
            var me = _dataContext.Me.Where(x => x.Id == model.Id);

            if (me == null)
                throw new CustomException($"There are no data of type {typeof(Me)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Me.Update(model);
            _dataContext.SaveChanges();
        }

        public void Delete()
        {
            var me = Get();

            if (me == null)
                throw new CustomException($"There are no data of type {typeof(Me)} to be deleted.", string.Empty, 412);

            _dataContext.Me.Remove(me);
            _dataContext.SaveChanges();
        }
    }
}
