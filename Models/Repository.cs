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

        public LinkContactViewModel GetAllClientsAndContacts()
        {
            return new LinkContactViewModel { clients = _context.clients.ToList(), contacts = _context.contacts.ToList() };
        }

        public void LinkClients(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public void LinkContact(Linked clientContactLink)
        {
            _context.linkeds.Add(clientContactLink);
            _context.SaveChanges();

            var client = _context.clients.SingleOrDefault(c => c.Id == clientContactLink.ClietId);

            if (client != null) { 
               client.Contacts = _context.linkeds.Where(l => l.ClietId == client.Id).ToList().Count;
                _context.SaveChanges();
            }

        }

        public IEnumerable<Linked> GetLinks()
        {
            return _context.linkeds.ToList();
        }

        public bool ContactLinked(Linked client)
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

        public void LinkClients(Linked client)
        {
            throw new NotImplementedException();
        }
    }
}
