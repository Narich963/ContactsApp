using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace ContactsApp.Data_Access;

public class ContactsAppContextFactory : IDesignTimeDbContextFactory<ContactsAppContext>
{
    private readonly string ConnectionString = "Server=Nariman\\MSSQLSERVER04;Database=contacts;Integrated Security=true;TrustServerCertificate=True;";
    public ContactsAppContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContactsAppContext>();
        optionsBuilder.UseSqlServer(ConnectionString);
        return new ContactsAppContext(optionsBuilder.Options);
    }
}
