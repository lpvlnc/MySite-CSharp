using Portfolio.Application.Interfaces;
using Portfolio.Data;
using Portfolio.ExceptionHandler;
using Portfolio.Model;

namespace Portfolio.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;

        public ContactService(DataContext context)
        {
            _dataContext = context;
        }

        public List<Contact> Get()
        {
            return _dataContext.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            var contact = _dataContext.Contacts.Where(x => x.Id == id).SingleOrDefault();
            return contact ?? throw new CustomException($"No data of type {typeof(Contact)} with Id {id} has been found.", string.Empty, 412);
        }

        public void Add(Contact model)
        {
            model.Id = 0;
            _dataContext.Contacts.Add(model);
            _dataContext.SaveChanges();
        }

        public void Update(Contact model)
        {
            var contact = _dataContext.Contacts.Find(model.Id);

            if (contact == null)
                throw new CustomException($"There are no data of type {typeof(Contact)} with id {model.Id} to update.", string.Empty, 412);

            _dataContext.Entry(contact).CurrentValues.SetValues(model);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = GetById(id);

            if (contact == null)
                throw new CustomException($"There are no data of type {typeof(Contact)} with Id {id} to be deleted.", string.Empty, 412);

            _dataContext.Contacts.Remove(contact);
            _dataContext.SaveChanges();
        }

        public string SendMessage(Message message)
        {
            return "Message sent";
        }
    }
}
