using ContactsApp.Data_Access;
using ContactsApp.Models;
using ContactsApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Windows;

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
        return await _context.Contacts
            .AsNoTracking()
            .OrderBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task AddOrEditAsync(ContactViewModel contactVM)
    {
        if (contactVM == null)
            throw new ArgumentNullException("Contact was null");

        try
        {
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
            {
                var existing = await _context.Contacts.FindAsync(contactVM.Id);
                if (existing == null)
                    throw new KeyNotFoundException($"The Contact with Id {contactVM.Id} not found");
                existing.FirstName = contactVM.FirstName;
                existing.LastName = contactVM.LastName;
                existing.PhoneNumber = contactVM.PhoneNumber;
                existing.Address = contactVM.Address;

                _context.Update(existing);
            }
        
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
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
