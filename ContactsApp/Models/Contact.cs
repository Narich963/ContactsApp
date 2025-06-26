using System.ComponentModel.DataAnnotations;

namespace ContactsApp.Models;

public class Contact
{
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(12)]
    public string PhoneNumber { get; set; }

    [StringLength(50)]
    public string Address { get; set; }
}
