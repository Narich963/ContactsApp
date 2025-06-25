using ContactsApp.Data_Access;
using ContactsApp.Models;
using ContactsApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Services;

public class ContactService : IContactService
{
    private readonly ContactsAppContext _context;

    public ContactService(ContactsAppContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAll()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task AddOrEditAsync(ContactViewModel contactVM)
    {
        if (contactVM == null)
            throw new ArgumentNullException("Contact was null");

        var contact = new Contact
        {
            Id = contactVM.IsNew ? 0 : contactVM.Id,
            FirstName = contactVM.FirstName,
            LastName = contactVM.LastName,
            PhoneNumber = contactVM.PhoneNumber,
            Address = contactVM.Address
        };

        if (contactVM.IsNew)
            await _context.AddAsync(contact);
        else
            _context.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
            throw new KeyNotFoundException("Contact not found");

        _context.Remove(contact);
        await _context.SaveChangesAsync();
    }
}
