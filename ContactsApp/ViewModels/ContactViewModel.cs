namespace ContactsApp.ViewModels;

public class ContactViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public bool IsNew { get; set; } = true;
}
