using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data_Access;

public class ContactsAppContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public ContactsAppContext(DbContextOptions<ContactsAppContext> opts) : base(opts)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
