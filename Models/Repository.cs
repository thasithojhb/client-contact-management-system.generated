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

        public void AddClient(Client clientName)
        {
            var client = new ClientViewModel
            {
                Name = clientName.Name,
                ClientCode = GenerateClientCode(clientName.Name),
            };
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
            return _context.contacts.Any(c => c.Email.ToLower() == email.ToLower());
        }

        public LinkContactViewModel GetAllClientsAndContacts()
        {
            return new LinkContactViewModel { clients = _context.clients.ToList(), contacts = _context.contacts.ToList() };
        }

        public void LinkClients(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public void LinkClientContact(Linked clientContactLink)
        {
            _context.linkeds.Add(clientContactLink);
            _context.SaveChanges();

            var client = _context.clients.SingleOrDefault(c => c.Id == clientContactLink.ClietId);
            var contact = _context.contacts.SingleOrDefault(c => c.Id == clientContactLink.ContactId);

            if (client != null) { 
               client.Contacts = _context.linkeds.Where(l => l.ClietId == client.Id).ToList().Count;
                _context.SaveChanges();
            }

            if (contact != null)
            {
                contact.Clients = _context.linkeds.Where(l => l.ContactId == contact.Id).ToList().Count;
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

        private string GenerateClientCode(string clientName)
        {

            var codeString = string.Empty;

            if (!string.IsNullOrEmpty(clientName))
            {
                if (clientName.Length >= 3)
                {
                    var nameSubstring = clientName.Split(' ');

                    if (nameSubstring.Length == 3)
                    {
                        codeString = nameSubstring[0].Substring(0, 1).ToUpper() + nameSubstring[1].Substring(0, 1).ToUpper() + nameSubstring[2].Substring(0, 1).ToUpper();
                    }

                    if (nameSubstring.Length == 1)
                    {
                         codeString = nameSubstring[0].Substring(0, 3).ToUpper();
                    }

                }
                else
                {
                    Random rand = new Random();

                    codeString = clientName.Length == 1 ? clientName.ToUpper() + (char)rand.Next(65, 91) + (char)rand.Next(65, 91) : clientName.ToUpper() + (char)rand.Next(65, 91);

                }
            }

            var code = _context.clients.ToList().Count + 1;


            return $"{codeString}{code:D3}"; ;
        }
    }
}
