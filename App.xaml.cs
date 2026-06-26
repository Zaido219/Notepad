using System.Configuration;
using System.Data;
using System.Windows;
using NotepadApp.ViewModels;
using NotepadApp.Views;

namespace NotepadApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // create the layers
            MainWindow window = new MainWindow();
            IMainViewModel viewModel = new MainViewModel();
            // hand the view model to the view
            window.DataContext = viewModel;
            // display the ui
            window.Show();
        }
    }

}

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
