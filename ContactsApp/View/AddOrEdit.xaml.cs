using ContactsApp.Services;
using ContactsApp.ViewModels;
using System.Windows;
using System.Windows.Media;

namespace ContactsApp.View;

/// <summary>
/// Interaction logic for AddOrEdit.xaml
/// </summary>
public partial class AddOrEdit : Window
{
    public AddOrEdit()
    {
        InitializeComponent();

        Loaded += Page_Loaded;
    }

    public void Page_Loaded(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is AddOrEditContactViewModel viewModel)
        {
            Title.Text = viewModel.Contact.IsNew ? "Create Contact" : "Edit Contact";
            SaveButton.Content = viewModel.Contact.IsNew ? "Create" : "Edit";
            SaveButton.Background = viewModel.Contact.IsNew ? Brushes.Blue : Brushes.Yellow;
        }
    }
    protected override void OnClosed(EventArgs e)
    {
        NavigationService.NavigateBack();
        base.OnClosed(e);
    }

    public void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        ((AddOrEditContactViewModel)this.DataContext).SaveAsync();
        NavigationService.NavigateBack();
    }
}
