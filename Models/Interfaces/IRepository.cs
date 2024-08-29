namespace client_contact_management_system.Models.Interfaces
{
    public interface IRepository
    {
        IEnumerable<ClientViewModel> GetAllClients();

        IEnumerable<ContactViewModel> GetAllContacts();

        void AddClient(ClientViewModel client);

        void AddContact(ContactViewModel client);

        bool ContactExist(string email);

        void LinkClients(ClientViewModel client);

        void LinkContacts(ClientViewModel client);

        void UnLinkClient(ClientViewModel client);

        void UnLinkContact(ClientViewModel client);
    }
}
