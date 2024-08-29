using Microsoft.EntityFrameworkCore;

namespace client_contact_management_system.Models
{
    public class ClientContactManagementContext : DbContext
    {

        public ClientContactManagementContext(DbContextOptions<ClientContactManagementContext> options) 
            : base(options)
        {
        }

        public DbSet<ClientViewModel> clients { get; set; }

        public DbSet<ContactViewModel> contacts { get; set; }

        public DbSet<Linked> linkeds { get; set; }
    }
}
