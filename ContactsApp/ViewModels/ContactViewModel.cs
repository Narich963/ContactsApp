using System.ComponentModel;

namespace ContactsApp.ViewModels;

public class ContactViewModel : INotifyPropertyChanged
{
    private int id;
    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
        }
    }

    private string firstName;
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            OnPropertyChanged();
        }
    }

    private string lastName;
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged();
        }
    }

    private string phoneNumber;
    public string PhoneNumber
    {
        get => phoneNumber;
        set
        {
            phoneNumber = value;
            OnPropertyChanged();
        }
    }

    private string address;
    public string Address
    {
        get => address;
        set
        {
            address = value;
            OnPropertyChanged();
        }
    }

    public bool IsNew { get; set; } = true;


    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
