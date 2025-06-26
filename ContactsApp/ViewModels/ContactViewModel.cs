using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.ViewModels;

public class ContactViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> _errors = new();

    private int id;
    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string firstName;

    [Required]
    [StringLength(50, ErrorMessage = "Max length of first name is 50 symbols")]
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string lastName;

    [Required]
    [StringLength(50, ErrorMessage = "Max length of last name is 50 symbols")]
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    private string phoneNumber;
    [Required]
    [MaxLength(13, ErrorMessage = "Max length of Phone number is 13 symbols")]
    [RegularExpression(@"^[\d\s]+$", ErrorMessage = "Invalid phone number format. Example: 0 123 456 789")]
    public string PhoneNumber
    {
        get => phoneNumber;
        set
        {
            phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

    private string address;
    [Required]
    [MaxLength(50, ErrorMessage = "Max length of Address is 50 symbols")]
    public string Address
    {
        get => address;
        set
        {
            address = value;
            OnPropertyChanged(nameof(Address));
        }
    }

    public bool IsNew { get; set; } = true;
    private bool isSaveButtonActive = false;
    public bool IsSaveButtonActive
    {
        get => isSaveButtonActive;
        set
        {
            isSaveButtonActive = value;
            OnPropertyChanged();
        }
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged(string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        ValidateProperty(name);
    }
    #endregion

    #region INotifyDataErrorInfo
    public bool HasErrors => _errors.Any();
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return null;
        return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
    }

    private void ValidateProperty(string property)
    {
        if (string.IsNullOrEmpty(property))
            return;

        var context = new ValidationContext(this)
        {
            MemberName = property
        };

        var results = new List<ValidationResult>();
        var value = GetType().GetProperty(property).GetValue(this);

        _errors.Remove(property);

        if (!Validator.TryValidateProperty(value, context, results))
        {
            _errors[property] = results.Select(r => r.ErrorMessage).ToList();
        }

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(property));
        IsSaveButtonActive = !_errors.Any() && !ArePropertiesNull();
    }

    private bool ArePropertiesNull()
    {
        return string.IsNullOrEmpty(FirstName)
            || string.IsNullOrEmpty(LastName)
            || string.IsNullOrEmpty(PhoneNumber)
            || string.IsNullOrEmpty(Address);
    }
    #endregion
}
