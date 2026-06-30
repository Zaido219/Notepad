using System.Windows;
using NotepadApp.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;


namespace NotepadApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // This method name must match the PreviewTextInput="TextBox_PreviewTextInput" attribute in your XAML
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 1. Extract inputs safely by verifying the sender is a TextBox and text exists
            if (sender is TextBox textBox && !string.IsNullOrEmpty(e.Text))
            {
                char typedChar = e.Text[0];
                int currentCaret = textBox.CaretIndex;

                // 2 & 3. Access DataContext, safely cast to your interface, and invoke
                if (this.DataContext is IMainViewModel viewModel)
                {
                    viewModel.ProcessKeyPress(typedChar, currentCaret);
                }
            }
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e){
            if(e.Key == Key.Space && sender is TextBox textBox)
            {
                if(this.DataContext is MainViewModel viewModel)
                {
                    viewModel.ProcessKeyPress(' ', textBox.CaretIndex);
                }
            }
        }
    }
}