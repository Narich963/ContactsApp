using ContactsApp.Data_Access;
using ContactsApp.Models;
using ContactsApp.Services;
using ContactsApp.View;
using ContactsApp.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ContactsApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IContactService _contactService;
    public MainWindow(MainWindowViewModel viewModel, IContactService contactService)
    {
        InitializeComponent();
        DataContext = viewModel;
        _contactService = contactService;
    }

    public void AddContact_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = new AddOrEditContactViewModel(_contactService);

        var window = new AddOrEdit
        {
            DataContext = viewModel
        };

        window.ShowDialog();
    }
    public void EditContact_Click(object sender, RoutedEventArgs e)
    {
         var selected = ContactsList.SelectedValue as Contact;

        var viewModel = new AddOrEditContactViewModel(_contactService);
        viewModel.Contact = new ContactViewModel
        {
            Id = selected.Id,
            FirstName = selected.FirstName,
            LastName = selected.LastName,
            PhoneNumber = selected.PhoneNumber,
            Address = selected.Address,
            IsNew = false
        };

        var window = new AddOrEdit
        {
            DataContext = viewModel
        };
        window.ShowDialog();
    }
    public void DeleteContact_Click(object sender, RoutedEventArgs e)
    {
        var selected = ContactsList.SelectedValue as Contact;

        _contactService.DeleteAsync(selected.Id);
    }
}