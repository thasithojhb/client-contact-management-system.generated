using System.ComponentModel.DataAnnotations;

namespace client_contact_management_system.Models
{
    public class ClientViewModel : Client
    {
        public int Id { get; set; } 

        [Required]
        public string? ClientCode { get; set; }

        public int Contacts { get; set; }
    }
}
