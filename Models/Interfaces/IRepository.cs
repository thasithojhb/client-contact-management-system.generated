namespace client_contact_management_system.Models.Interfaces
{
    public interface IRepository
    {
        public IEnumerable<ClientViewModel> GetAllClients();

        public IEnumerable<ContactViewModel> GetAllContacts();

        public LinkContactViewModel GetAllClientsAndContacts();

        public IEnumerable<Linked> GetLinks();

        public void AddClient(ClientViewModel client);

        public void AddContact(ContactViewModel client);

        public bool ContactExist(string email);

        public void LinkClients(Linked client);

        public void LinkContact(Linked client);

        public bool ContactLinked(Linked client);

        public void UnLinkClient(ClientViewModel client);

        public void UnLinkContact(ClientViewModel client);
    }
}
