using Portfolio.Model;

namespace Portfolio.Application.Interfaces
{
    public interface IContactService
    {
        public List<Contact> Get();
        public Contact GetById(int id);
        public void Add(Contact model);
        public void Update(Contact model);
        public void Delete(int id);
        public string SendMessage(Message message);
    }
}
