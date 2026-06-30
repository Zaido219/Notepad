using System.Configuration;
using System.Data;
using System.Windows;
using NotepadApp.Services;
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
            IFileService fileService = new FileService();
            ITransactionManager transactionManager= new TransactionManager();
            IMainViewModel viewModel = new MainViewModel(fileService, transactionManager);
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
