using System.ComponentModel.DataAnnotations;

namespace client_contact_management_system.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Email { get; set; }

        public int Clients { get; set; }
    }
}
