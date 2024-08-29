using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace client_contact_management_system.Models
{
    public class ClientContactManagementContextFactory : IDesignTimeDbContextFactory<ClientContactManagementContext>
    {
        public ClientContactManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClientContactManagementContext>();

            optionsBuilder.UseSqlite(@"Data Source=Database\ClientContactManagement.db");

            return new ClientContactManagementContext(optionsBuilder.Options);
        }
    }
}
