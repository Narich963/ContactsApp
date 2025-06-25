using ContactsApp.Data_Access;
using System.Windows;

namespace ContactsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ContactsAppContext _context;
    public MainWindow(ContactsAppContext context)
    {
        _context = context;
        var contacts = _context.Contacts.ToList();
        InitializeComponent();
    }
}