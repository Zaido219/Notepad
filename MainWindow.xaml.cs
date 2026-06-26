using System.Windows;
using NotepadApp.ViewModels;

namespace NotepadApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // This will work now!
        }

        private void NewMenu_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is IMainViewModel viewModel)
            {
                viewModel.NewDocument();
            }
        }
    }
} // Make sure this closing brace is at the very end of your file