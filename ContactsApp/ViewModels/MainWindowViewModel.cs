using ContactsApp.Models;
using ContactsApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ContactsApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly IContactService _contactService;
    private ObservableCollection<Contact> _contacts;

    public ObservableCollection<Contact> Contacts
    {
        get => _contacts;
        set
        {
            _contacts = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(IContactService contactService)
    {
        _contactService = contactService;

        LoadContactsAsync();
    }

    private async Task LoadContactsAsync()
    {
        try
        {
            var contacts = await _contactService.GetAll();
            Contacts = new ObservableCollection<Contact>(contacts);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Loading error: {ex.Message}");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName]string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
