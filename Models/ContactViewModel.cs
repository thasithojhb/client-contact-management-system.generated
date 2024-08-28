namespace client_contact_management_system.Models
{
    public class ContactViewModel
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public List<ClientViewModel>? Contacts { get; set; }
    }
}
