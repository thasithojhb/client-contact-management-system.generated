using client_contact_management_system.Models.Interfaces;

namespace client_contact_management_system.Models
{
    public class Repository : IRepository
    {
        private readonly ClientContactManagementContext _context;

        public Repository(ClientContactManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientViewModel> GetAllClients()
        {
            return _context.clients.OrderBy(c => c.Name).ToList();
        }

        public void AddClient(ClientViewModel client)
        {
            _context.clients.Add(client);
            _context.SaveChanges();
        }

        public IEnumerable<ContactViewModel> GetAllContacts()
        {
            return _context.contacts.OrderBy(c => c.Name).ToList();
        }

        public void AddContact(ContactViewModel contact)
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
        }

        public bool ContactExist(string email)
        {
            return _context.contacts.Any(c => c.Email == email);
        }
        public void LinkClients(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public void LinkContacts(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public void UnLinkClient(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public void UnLinkContact(ClientViewModel client)
        {
            throw new NotImplementedException();
        }
    }
}
