using ContactsApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactsApp.ViewModels;

public class AddOrEditContactViewModel : INotifyPropertyChanged
{
    private readonly IContactService _contactService;

    public AddOrEditContactViewModel(IContactService contactService)
    {
        _contactService = contactService;
        Contact = new ContactViewModel();
    }

    private ContactViewModel _contact;
    public ContactViewModel Contact
    {
        get => _contact;
        set
        {
            _contact = value;
            OnPropertyChanged(nameof(Contact));
        }
    }

    public async Task SaveAsync()
    {
        await _contactService.AddOrEditAsync(Contact);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
