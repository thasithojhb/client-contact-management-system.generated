namespace client_contact_management_system.Models
{
    public class LinkContactViewModel
    {
        public IEnumerable<ClientViewModel>? clients { get; set; }

        public IEnumerable<ContactViewModel>? contacts { get; set; }
    }
}
