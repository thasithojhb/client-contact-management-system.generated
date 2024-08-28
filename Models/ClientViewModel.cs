namespace client_contact_management_system.Models
{
    public class ClientViewModel
    {
        public required string Name { get; set; }
        public required string ClientCode { get; set; }
        public List<ContactViewModel>? Contacts { get; set; }
    }
}
