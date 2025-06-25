using ContactsApp.Models;
using ContactsApp.ViewModels;

namespace ContactsApp.Services;

public interface IContactService
{
    Task<List<Contact>> GetAll();
    Task AddOrEditAsync(ContactViewModel contactVM);
    Task DeleteAsync(int id);
}
